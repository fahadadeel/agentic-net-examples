using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an AutoShape (rectangle) to the slide
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Add a TextFrame to the shape
        autoShape.AddTextFrame("Sample Text");

        // Access the text frame, paragraph, and portion
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Set supported font properties
        portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");
        portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
        portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Green;

        // Save the presentation
        presentation.Save("SupportedFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}