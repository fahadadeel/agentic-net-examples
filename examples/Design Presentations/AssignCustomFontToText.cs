using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle autoshape to the first slide
            Aspose.Slides.IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

            // Initialize a text frame for the shape
            autoShape.AddTextFrame("");

            // Create a paragraph and a portion with sample text
            Aspose.Slides.Paragraph paragraph = new Aspose.Slides.Paragraph();
            Aspose.Slides.Portion portion = new Aspose.Slides.Portion("Sample text with custom font");
            paragraph.Portions.Add(portion);

            // Add the paragraph to the shape's text frame
            autoShape.TextFrame.Paragraphs.Add(paragraph);

            // Assign a custom Latin font to the text portion
            portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("MyCustomFont");

            // Save the presentation
            presentation.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}