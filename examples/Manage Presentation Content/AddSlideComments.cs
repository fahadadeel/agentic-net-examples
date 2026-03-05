using System;
using System.Drawing;
using Aspose.Slides;

namespace AsposeSlidesComments
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Add a comment author
                Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

                // Define comment position
                System.Drawing.PointF position = new System.Drawing.PointF();
                position.X = 0.2f;
                position.Y = 0.2f;

                // Add a comment to the first slide
                Aspose.Slides.IComment comment = author.Comments.AddComment(
                    "This is a comment on slide 1",
                    presentation.Slides[0],
                    position,
                    System.DateTime.Now);

                // Add another comment to the second slide if it exists
                if (presentation.Slides.Count > 1)
                {
                    Aspose.Slides.IComment comment2 = author.Comments.AddComment(
                        "Comment on slide 2",
                        presentation.Slides[1],
                        position,
                        System.DateTime.Now);
                }

                // Save the presentation
                presentation.Save("Comments_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}