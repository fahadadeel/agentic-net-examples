using System;

namespace DeleteCommentsAndAuthors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Delete all comment authors and their comments
            for (int i = presentation.CommentAuthors.Count - 1; i >= 0; i--)
            {
                Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors[i];
                // Remove all comments made by this author
                author.Comments.Clear();
                // Remove the author from the collection
                presentation.CommentAuthors.Remove(author);
            }

            // Save the modified presentation in PPTX format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}