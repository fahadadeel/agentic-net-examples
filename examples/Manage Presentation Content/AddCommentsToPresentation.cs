using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ModernCommentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a comment author
            Aspose.Slides.ICommentAuthor commentAuthor = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

            // Define the position for the modern comment
            PointF commentPosition = new PointF(100f, 100f);

            // Add a modern comment to the first slide
            Aspose.Slides.IModernComment modernComment = commentAuthor.Comments.AddModernComment(
                "This is a modern comment added via Aspose.Slides",
                presentation.Slides[0],
                null,
                commentPosition,
                DateTime.Now);

            // Save the presentation
            presentation.Save("ModernComments_out.pptx", SaveFormat.Pptx);
        }
    }
}