using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape to the slide
        Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse, // shape type
            100, 100,                       // X and Y position
            200, 150);                      // Width and Height

        // Set solid fill color for the ellipse
        ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        ellipse.FillFormat.SolidFillColor.Color = Color.LightBlue;

        // Set line (border) format
        ellipse.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        ellipse.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        ellipse.LineFormat.Width = 3;

        // Save the presentation
        presentation.Save("EllipsePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}