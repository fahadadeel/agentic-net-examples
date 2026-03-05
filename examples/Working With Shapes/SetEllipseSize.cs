using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);

        // Set the size of the ellipse
        ellipse.Width = 300;
        ellipse.Height = 150;

        // Save the presentation
        presentation.Save("EllipseSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}