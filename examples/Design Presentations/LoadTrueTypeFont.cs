using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LoadTrueTypeFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the TrueType font file
            string fontPath = "C:\\Fonts\\CustomFont.ttf";

            // Load the font data into memory
            byte[] fontData = File.ReadAllBytes(fontPath);

            // Register the external font with Aspose.Slides
            Aspose.Slides.FontsLoader.LoadExternalFont(fontData);

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 150, 300, 50);

            // Add a text frame with sample text
            shape.AddTextFrame("Sample text using custom TrueType font");

            // Access the first paragraph and portion
            Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];
            Aspose.Slides.IPortion portion = paragraph.Portions[0];

            // Apply the loaded TrueType font to the text
            portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("CustomFont");

            // Save the presentation
            pres.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            pres.Dispose();
            Aspose.Slides.FontsLoader.ClearCache();
        }
    }
}