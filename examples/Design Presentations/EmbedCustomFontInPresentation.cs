using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedCustomFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the folder containing the custom TrueType font
            string dataDir = "C:\\Data\\";
            string fontFilePath = Path.Combine(dataDir, "CustomFont.ttf");

            // Load the font file into a byte array
            byte[] fontBytes = File.ReadAllBytes(fontFilePath);

            // Load the custom font folder before creating the presentation (optional, ensures availability)
            string[] fontFolders = new string[] { dataDir };
            FontsLoader.LoadExternalFonts(fontFolders);

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Embed the custom font into the presentation (embed all characters)
                presentation.FontsManager.AddEmbeddedFont(fontBytes, EmbedFontCharacters.All);

                // Add a slide and a text shape using the embedded font
                ISlide slide = presentation.Slides[0];
                IAutoShape autoShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
                ITextFrame textFrame = autoShape.AddTextFrame("Sample text using custom font");
                IPortion portion = textFrame.Paragraphs[0].Portions[0];
                portion.PortionFormat.FontHeight = 24;
                portion.PortionFormat.LatinFont = new FontData("CustomFont");

                // Save the presentation
                presentation.Save("EmbeddedCustomFontPresentation.pptx", SaveFormat.Pptx);
            }

            // Clear the custom font cache
            FontsLoader.ClearCache();
        }
    }
}