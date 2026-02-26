using System;
using System.Drawing;
using Aspose.Slides;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a comment author
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

            // Define comment position
            System.Drawing.PointF position = new System.Drawing.PointF(150f, 150f);

            // Add a modern comment to the first slide
            Aspose.Slides.IModernComment modernComment = author.Comments.AddModernComment(
                "This is a modern comment added via Aspose.Slides.",
                presentation.Slides[0],
                null,
                position,
                DateTime.Now);

            // Save the presentation
            presentation.Save("ModernComments_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}