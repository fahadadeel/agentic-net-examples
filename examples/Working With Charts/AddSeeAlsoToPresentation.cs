using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape to the slide
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);

        // Add a TextFrame with "See also" text
        autoShape.AddTextFrame("See also");

        // Add a modern comment associated with the shape
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author Name", "AN");
        Aspose.Slides.IModernComment modernComment = author.Comments.AddModernComment(
            "See also reference",
            slide,
            autoShape,
            new System.Drawing.PointF(150, 150),
            System.DateTime.Now);

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}