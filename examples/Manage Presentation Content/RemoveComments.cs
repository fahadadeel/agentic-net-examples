using System;

namespace RemoveCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "Comments1.pptx";
            string outputPath = "Comments_removed.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides and remove all comments
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);
                for (int commentIndex = 0; commentIndex < comments.Length; commentIndex++)
                {
                    Aspose.Slides.IComment comment = comments[commentIndex];
                    comment.Remove();
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}