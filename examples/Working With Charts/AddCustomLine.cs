using System;
using System.Drawing;
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

        // Add a custom line shape
        Aspose.Slides.IAutoShape line = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 400, 0);

        // Set line width
        line.LineFormat.Width = 5;

        // Set line color to solid blue
        line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        presentation.Save("CustomLinePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}