using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

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

            // Get the collection of comment authors
            Aspose.Slides.ICommentAuthorCollection authors = presentation.CommentAuthors;

            // Copy authors to a list to avoid modification during enumeration
            List<Aspose.Slides.ICommentAuthor> authorList = new List<Aspose.Slides.ICommentAuthor>();
            foreach (Aspose.Slides.ICommentAuthor author in authors)
            {
                authorList.Add(author);
            }

            // Remove all comments and authors
            foreach (Aspose.Slides.ICommentAuthor author in authorList)
            {
                // Clear all comments made by this author
                author.Comments.Clear();

                // Remove the author from the collection
                author.Remove();
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}