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

        // Add a rectangle shape with some text
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 100);
        shape.AddTextFrame("Sample Text");

        // Set text background color (highlight) to Yellow
        Aspose.Slides.IPortion portion = shape.TextFrame.Paragraphs[0].Portions[0];
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;

        // Save the presentation
        presentation.Save("TextBackgroundColor_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}