using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation (starts with one empty slide)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a comment author to the presentation
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

        // Define the position where the comment will appear on the slide
        PointF position = new PointF();
        position.X = 0.5f; // relative X position (0.0 - 1.0)
        position.Y = 0.5f; // relative Y position (0.0 - 1.0)

        // Add a comment to the first slide using the author and position
        Aspose.Slides.IComment comment = author.Comments.AddComment(
            "This is a comment on slide 1",
            presentation.Slides[0],
            position,
            DateTime.Now);

        // Optionally set a document-level comment property
        presentation.DocumentProperties.Comments = "Presentation with slide comments";

        // Save the presentation in PPT format
        presentation.Save("PresentationWithComments.ppt", SaveFormat.Ppt);
    }
}