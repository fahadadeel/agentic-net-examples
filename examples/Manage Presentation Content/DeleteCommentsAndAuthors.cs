using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the collection of comment authors
        Aspose.Slides.ICommentAuthorCollection authors = presentation.CommentAuthors;

        // Copy authors to an array to avoid modification during iteration
        Aspose.Slides.ICommentAuthor[] authorArray = new Aspose.Slides.ICommentAuthor[authors.Count];
        for (int i = 0; i < authors.Count; i++)
        {
            authorArray[i] = authors[i];
        }

        // Remove all comments and authors
        for (int i = 0; i < authorArray.Length; i++)
        {
            Aspose.Slides.ICommentAuthor author = authorArray[i];
            // Clear comments of the author
            author.Comments.Clear();
            // Remove the author from the collection
            authors.Remove(author);
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}