using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add an ellipse shape to the slide
        var ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 150);

        // Apply line formatting to the ellipse
        ellipse.LineFormat.Width = 5; // Set line width (points)
        ellipse.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash; // Set dash style
        ellipse.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid; // Use solid fill for the line
        ellipse.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue; // Set line color

        // Save the presentation
        presentation.Save("EllipseLineFormat.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}