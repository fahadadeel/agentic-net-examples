using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "CommentsInput.pptx";
                string outputPath = "CommentsOutput.pptx";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate existing comments (optional, just to show they are preserved)
                    foreach (ICommentAuthor author in presentation.CommentAuthors)
                    {
                        foreach (IComment comment in author.Comments)
                        {
                            Console.WriteLine("Slide " + comment.Slide.SlideNumber + ": " + author.Name + " - " + comment.Text);
                        }
                    }

                    // Save the presentation to PPTX format, preserving all comment metadata
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}