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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Set the line color to red
        lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation
        presentation.Save("LineColor_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}