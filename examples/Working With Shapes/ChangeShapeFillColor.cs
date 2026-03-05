using System;
using Aspose.Slides;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Set fill type to solid
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;

        // Set fill color to red
        shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        // Save the presentation
        presentation.Save("ShapeFillColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}