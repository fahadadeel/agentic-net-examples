using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);

        // Add a text frame with some text
        Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame("Centered Text");

        // Get the first paragraph and set its alignment to center
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

        // Save the presentation
        pres.Save("AlignedParagraph_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}