using System;
using System.IO;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the custom font file (TrueType font)
            string fontPath = "customfont.ttf";

            // Load the font data into memory
            byte[] fontData = File.ReadAllBytes(fontPath);
            Aspose.Slides.FontsLoader.LoadExternalFont(fontData);

            // Create a new empty presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a new empty slide based on the layout of the first slide
            Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

            // Add a rectangle AutoShape to the slide
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 50);

            // Add a TextFrame with sample text
            autoShape.AddTextFrame("Hello with custom font!");

            // Apply the custom font to each portion of the first paragraph
            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
            foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
            {
                portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("CustomFont");
            }

            // Save the presentation to a PPTX file
            pres.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clear the loaded custom fonts from the cache
            Aspose.Slides.FontsLoader.ClearCache();

            // Release resources
            pres.Dispose();
        }
    }
}