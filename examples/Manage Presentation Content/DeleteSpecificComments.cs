using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all comment authors in the presentation
        foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
        {
            // Cast to concrete CommentAuthor to access its Comments collection
            Aspose.Slides.CommentAuthor commentAuthor = (Aspose.Slides.CommentAuthor)author;

            // Collect comments that contain the word "Heading" in their text
            List<Aspose.Slides.IComment> commentsToRemove = new List<Aspose.Slides.IComment>();
            foreach (Aspose.Slides.IComment comment in commentAuthor.Comments)
            {
                Aspose.Slides.Comment c = (Aspose.Slides.Comment)comment;
                if (c.Text != null && c.Text.Contains("Heading"))
                {
                    commentsToRemove.Add(c);
                }
            }

            // Remove the collected comments from the presentation
            foreach (Aspose.Slides.IComment comment in commentsToRemove)
            {
                comment.Remove();
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}