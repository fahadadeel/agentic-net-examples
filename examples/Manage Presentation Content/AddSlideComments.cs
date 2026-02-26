using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add an empty slide (now we have two slides: index 0 and 1)
        pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

        // Add a comment author
        Aspose.Slides.ICommentAuthor author = pres.CommentAuthors.AddAuthor("Author Name", "AN");

        // Define comment position on the slide
        System.Drawing.PointF position = new System.Drawing.PointF(10f, 10f);

        // Add a comment to the first slide
        author.Comments.AddComment("First slide comment", pres.Slides[0], position, System.DateTime.Now);

        // Add a comment to the second slide
        author.Comments.AddComment("Second slide comment", pres.Slides[1], position, System.DateTime.Now);

        // (Optional) Retrieve comments for each slide
        Aspose.Slides.ISlide slide0 = pres.Slides[0];
        Aspose.Slides.IComment[] slide0Comments = slide0.GetSlideComments(author);

        Aspose.Slides.ISlide slide1 = pres.Slides[1];
        Aspose.Slides.IComment[] slide1Comments = slide1.GetSlideComments(null);

        // Save the presentation in PPT format
        pres.Save("AddSlideComments_out.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Dispose the presentation object
        pres.Dispose();
    }
}