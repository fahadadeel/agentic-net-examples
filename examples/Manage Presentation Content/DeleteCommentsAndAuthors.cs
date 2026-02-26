using System;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Remove all comments from each slide
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);
            foreach (Aspose.Slides.IComment comment in comments)
            {
                comment.Remove();
            }
        }

        // Clear all comment authors
        presentation.CommentAuthors.Clear();

        // Save the modified presentation in PPT format
        presentation.Save("output.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Release resources
        presentation.Dispose();
    }
}