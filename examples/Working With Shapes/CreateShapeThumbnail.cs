using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "ShapeThumbnail.pptx";
        string outputPng = "ShapeThumbnail.png";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50,   // X position
            50,   // Y position
            200,  // Width
            100   // Height
        );

        // Set shape formatting
        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

        // Generate thumbnail image of the shape
        Aspose.Slides.IImage shapeImage = shape.GetImage(
            Aspose.Slides.ShapeThumbnailBounds.Shape,
            1.0f, // Scale X
            1.0f  // Scale Y
        );

        // Save the thumbnail as PNG
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}