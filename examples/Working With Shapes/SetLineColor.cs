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

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Set the line format to solid fill
        lineShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;

        // Apply red color to the line
        lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation
        presentation.Save("LineColorExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}