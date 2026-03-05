using System;

class Program
{
    static void Main(string[] args)
    {
        // Output file paths
        string outputPptx = "output.pptx";
        string outputPng = "shape.png";

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

        // Set shape fill to no fill
        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

        // Set line sketch type
        shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

        // Generate thumbnail image of the shape (full scale)
        Aspose.Slides.IImage shapeImage = shape.GetImage(
            Aspose.Slides.ShapeThumbnailBounds.Shape,
            1f,   // Scale X
            1f    // Scale Y
        );

        // Save the thumbnail as PNG
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}