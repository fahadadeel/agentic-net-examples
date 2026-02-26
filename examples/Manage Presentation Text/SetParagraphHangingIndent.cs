using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetHangingIndentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape to the slide
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 100);

            // Add a text frame with sample text
            autoShape.AddTextFrame("This paragraph demonstrates a hanging indent applied via Aspose.Slides.");

            // Get the first paragraph of the text frame
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Set a negative first line indent to create a hanging indent
            paragraph.ParagraphFormat.Indent = -30f; // Adjust the value as needed

            // Save the presentation
            presentation.Save("HangingIndent_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}