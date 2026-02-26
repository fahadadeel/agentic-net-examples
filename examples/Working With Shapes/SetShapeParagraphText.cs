using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape to the slide
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a TextFrame with initial text
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Initial Text");

        // Access the first paragraph of the TextFrame
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

        // Set custom text for the paragraph
        paragraph.Text = "This is a custom paragraph string.";

        // Save the presentation
        presentation.Save("CustomParagraph.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}