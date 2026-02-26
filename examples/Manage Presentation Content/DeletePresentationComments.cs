using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Text of the comment to be deleted
        string commentToDelete = "DeleteMe";

        // Iterate through all comment authors
        foreach (Aspose.Slides.ICommentAuthor commentAuthor in presentation.CommentAuthors)
        {
            // Collect comments that match the criteria
            List<Aspose.Slides.IComment> commentsToRemove = new List<Aspose.Slides.IComment>();

            foreach (Aspose.Slides.IComment comment in commentAuthor.Comments)
            {
                if (comment.Text == commentToDelete)
                {
                    commentsToRemove.Add(comment);
                }
            }

            // Remove the collected comments
            foreach (Aspose.Slides.IComment comment in commentsToRemove)
            {
                comment.Remove();
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}