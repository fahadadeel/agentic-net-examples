using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);

        // Add a text frame to the shape
        shape.AddTextFrame("Initial text");

        // Get the text frame
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

        // Get the first paragraph of the text frame
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

        // Set custom text for the paragraph
        paragraph.Text = "Custom paragraph text";

        // Save the presentation
        presentation.Save("ParagraphText_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}