using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50f,   // X position
            50f,   // Y position
            200f,  // Width
            100f   // Height
        );

        // Set the shape's fill type to solid and apply a color
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Chocolate;

        // Save the presentation in PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}