using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation from a PPTX file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Iterate through each comment author in the presentation
                foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                {
                    // Collect comments to a separate list to avoid modifying the collection while iterating
                    List<Aspose.Slides.IComment> commentsToRemove = new List<Aspose.Slides.IComment>();
                    foreach (Aspose.Slides.IComment comment in author.Comments)
                    {
                        commentsToRemove.Add(comment);
                    }

                    // Remove each comment using its Remove method
                    foreach (Aspose.Slides.IComment comment in commentsToRemove)
                    {
                        comment.Remove();
                    }
                }

                // Save the modified presentation to a new PPTX file
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}