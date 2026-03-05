using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "output.pptx";
        string outputPng = "paragraph2.png";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape with a text frame
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

        // Add two paragraphs to the shape's text frame
        shape.TextFrame.Text = "First paragraph.\nSecond paragraph.";

        // Access the second paragraph (index 1)
        Aspose.Slides.IParagraph secondParagraph = shape.TextFrame.Paragraphs[1];

        // Generate a thumbnail image of the shape (which contains the paragraphs)
        Aspose.Slides.IImage shapeImage = shape.GetImage(
            Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);

        // Save the thumbnail as PNG (represents the paragraph image)
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}