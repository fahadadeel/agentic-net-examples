using System;
using Aspose.Slides;

namespace ParagraphIndentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape with some size
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

            // Add a text frame to the shape and set its text
            autoShape.AddTextFrame("This is a sample paragraph.");

            // Get the first paragraph of the text frame
            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

            // Set the paragraph indent (in points)
            paragraph.ParagraphFormat.Indent = 20f;

            // Save the presentation
            presentation.Save("ParagraphIndent_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}