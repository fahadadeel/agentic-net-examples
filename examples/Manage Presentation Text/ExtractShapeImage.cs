using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "ShapeThumbnailOutput.pptx";
        string outputPng = "ShapeThumbnail.png";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Set shape fill to no fill
        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

        // Set line sketch type to Scribble
        shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

        // Define scaling factors (2x)
        float scaleX = 2f;
        float scaleY = 2f;

        // Generate shape thumbnail with scaling
        Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);

        // Save the shape thumbnail as PNG
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}