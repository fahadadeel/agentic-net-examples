using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a comment author to the presentation
        Aspose.Slides.ICommentAuthor commentAuthor = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

        // Add a modern comment to the first slide at position (100, 100)
        Aspose.Slides.IModernComment modernComment = commentAuthor.Comments.AddModernComment(
            "This is a modern comment",
            presentation.Slides[0],
            null,
            new PointF(100, 100),
            DateTime.Now);

        // Save the presentation to a PPTX file
        presentation.Save("ModernCommentPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}