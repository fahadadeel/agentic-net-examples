using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add a rectangle auto shape with a text frame
        var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        shape.AddTextFrame("This is a sample paragraph.");

        // Get the first paragraph of the text frame
        var textFrame = shape.TextFrame;
        var paragraph = textFrame.Paragraphs[0];

        // Set hanging indent (negative value) for the paragraph
        paragraph.ParagraphFormat.Indent = -30f;

        // Save the presentation
        presentation.Save("HangingIndent_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}