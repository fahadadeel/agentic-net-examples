using System;
using System.Drawing;

namespace PresentationTextFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape with a text frame
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("Sample Text");

            // Access the text frame and its first paragraph
            Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Center align the paragraph
            paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

            // Format the first portion (font size, italic, color)
            Aspose.Slides.IPortion portion = paragraph.Portions[0];
            portion.PortionFormat.FontHeight = 24;
            portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
            portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            presentation.Save("FormattedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}