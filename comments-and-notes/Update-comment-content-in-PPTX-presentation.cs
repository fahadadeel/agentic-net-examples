using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdateCommentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "Comments1.pptx";
            string outputPath = "Comments_updated.pptx";

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through comment authors and their comments
                foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                {
                    foreach (Aspose.Slides.IComment comment in author.Comments)
                    {
                        // Update the comment text
                        comment.Text = "This comment has been updated.";
                        // Assuming only one comment needs to be updated
                        break;
                    }
                    // Exit after updating the first comment found
                    break;
                }

                // Save the presentation with the updated comment
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}