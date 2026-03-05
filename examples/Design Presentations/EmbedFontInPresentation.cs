using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedTrueTypeFont
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load external TrueType fonts from a folder (adjust the path as needed)
            string[] fontFolders = new string[] { "C:\\Fonts" };
            Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Read the TrueType font file into a byte array (adjust the file name as needed)
            byte[] fontBytes = System.IO.File.ReadAllBytes("C:\\Fonts\\CustomFont.ttf");

            // Embed the font into the presentation (embed all characters)
            presentation.FontsManager.AddEmbeddedFont(fontBytes, Aspose.Slides.Export.EmbedFontCharacters.All);

            // Save the presentation with the embedded font
            presentation.Save("EmbeddedFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}