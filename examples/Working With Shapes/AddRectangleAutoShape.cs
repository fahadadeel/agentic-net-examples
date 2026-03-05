using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to the slide
            Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

            // Set fill color (optional)
            rectangle.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Save the presentation
            presentation.Save("RectangleShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}