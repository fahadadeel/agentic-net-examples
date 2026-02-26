using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape to the slide
        Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse, // shape type
            100, 100,                       // X and Y position
            200, 150);                      // width and height

        // Set solid fill for the ellipse
        ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        ellipse.FillFormat.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        presentation.Save("EllipseFill.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}