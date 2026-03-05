using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape with a text frame
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        autoShape.AddTextFrame("Hello [placeholder] World!");

        // Define the formatting for the replacement text
        Aspose.Slides.PortionFormat format = new Aspose.Slides.PortionFormat();
        format.FontHeight = 24f;
        format.FontItalic = Aspose.Slides.NullableBool.True;
        format.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.Red;

        // Replace the placeholder with formatted text
        Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true,
            "[placeholder]", "Formatted", format);

        // Save the presentation as PPTX
        presentation.Save("FormattedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}