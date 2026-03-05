using System;
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

        // Add a rectangle autoshape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Add a text frame to the shape
        Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame("");

        // Create a paragraph and a portion with custom font
        Aspose.Slides.Paragraph paragraph = new Aspose.Slides.Paragraph();
        Aspose.Slides.Portion portion = new Aspose.Slides.Portion("Sample text with custom font");
        // Assign a custom Latin font to the portion
        portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("Comic Sans MS");

        // Add the portion to the paragraph and the paragraph to the text frame
        paragraph.Portions.Add(portion);
        textFrame.Paragraphs.Add(paragraph);

        // Save the presentation
        presentation.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}