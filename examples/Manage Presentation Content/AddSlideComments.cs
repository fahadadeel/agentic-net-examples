using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add an empty slide based on the first layout slide
        pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

        // Add a comment author
        Aspose.Slides.ICommentAuthor author = pres.CommentAuthors.AddAuthor("Jawad", "MF");

        // Define comment position
        System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);

        // Add comment to the first slide
        author.Comments.AddComment("Hello Jawad, this is slide comment", pres.Slides[0], position, DateTime.Now);

        // Add a second empty slide to have a second slide
        pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

        // Add comment to the second slide
        author.Comments.AddComment("Hello Jawad, this is second slide comment", pres.Slides[1], position, DateTime.Now);

        // Save the presentation in PPTX format
        pres.Save("Comments_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        pres.Dispose();
    }
}