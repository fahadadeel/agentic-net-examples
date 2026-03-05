using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace PortionFormattingDemo
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to hold the text
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

            // Create a new paragraph
            Paragraph paragraph = new Paragraph();

            // Create a new portion with initial text
            Portion portion = new Portion("Formatted text");

            // Add the portion to the paragraph
            paragraph.Portions.Add(portion);

            // Add the paragraph to the shape's text frame
            shape.TextFrame.Paragraphs.Add(paragraph);

            // Apply character formatting to the portion
            IPortionFormat portionFormat = portion.PortionFormat;
            portionFormat.FontHeight = 24f;
            portionFormat.FontBold = NullableBool.True;
            portionFormat.FontItalic = NullableBool.True;
            portionFormat.FontUnderline = TextUnderlineType.Single;
            portionFormat.FillFormat.FillType = FillType.Solid;
            portionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            presentation.Save("PortionFormatting_out.pptx", SaveFormat.Pptx);
        }
    }
}