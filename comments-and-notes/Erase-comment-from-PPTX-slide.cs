using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the target slide (e.g., first slide)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Retrieve all comments on the slide
            Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

            // Define the author name of the comment to be removed
            string targetAuthor = "John Doe";

            // Iterate through comments and remove the matching one
            foreach (Aspose.Slides.IComment comment in comments)
            {
                if (comment.Author != null && comment.Author.Name == targetAuthor)
                {
                    // Remove the comment while keeping other comments intact
                    comment.Remove();
                    break; // Exit after removing the designated comment
                }
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}