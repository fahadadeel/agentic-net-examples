using System;
using Aspose.Slides;
using Aspose.Slides.Export;
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
            Aspose.Slides.ShapeType.Ellipse, 50, 150, 200, 100);

        // Set the fill to solid blue
        ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        ellipse.FillFormat.SolidFillColor.Color = Color.Blue;

        // Set the outline to a solid black line
        ellipse.LineFormat.Width = 2;
        ellipse.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        ellipse.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;

        // Save the presentation
        presentation.Save("EllipsePresentation.pptx", SaveFormat.Pptx);
    }
}