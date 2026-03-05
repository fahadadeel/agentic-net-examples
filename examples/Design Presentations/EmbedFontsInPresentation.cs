using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedFontsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            using (Presentation presentation = new Presentation("Fonts.pptx"))
            {
                // Retrieve all fonts used in the presentation
                IFontData[] allFonts = presentation.FontsManager.GetFonts();

                // Retrieve fonts that are already embedded
                IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                // Embed fonts that are not yet embedded
                foreach (IFontData font in allFonts)
                {
                    if (!embeddedFonts.Contains(font))
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                    }
                }

                // Save the presentation with embedded fonts
                presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
            }
        }
    }
}