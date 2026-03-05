using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        var sourcePath = "input.pptx";

        // Load the presentation
        var presentation = new Aspose.Slides.Presentation(sourcePath);

        // Text that identifies comments to be removed
        var targetText = "DeleteMe";

        // Iterate through all comment authors in the presentation
        foreach (var authorObj in presentation.CommentAuthors)
        {
            var author = (Aspose.Slides.CommentAuthor)authorObj;

            // Create a copy of the author's comments to avoid modifying the collection while iterating
            var commentsCopy = new List<Aspose.Slides.IComment>(author.Comments);

            // Check each comment for the target text
            foreach (var commentObj in commentsCopy)
            {
                var comment = (Aspose.Slides.Comment)commentObj;

                if (comment.Text != null && comment.Text.Contains(targetText))
                {
                    // Remove the comment and all its replies
                    comment.Remove();
                }
            }
        }

        // Save the modified presentation
        var outputPath = "output.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}