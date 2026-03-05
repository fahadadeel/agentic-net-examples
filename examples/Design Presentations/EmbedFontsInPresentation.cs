using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("Fonts.pptx");

        // Retrieve all fonts used in the presentation
        Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();

        // Retrieve fonts that are already embedded
        Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

        // Embed fonts that are not yet embedded
        foreach (Aspose.Slides.IFontData font in allFonts)
        {
            bool alreadyEmbedded = false;
            foreach (Aspose.Slides.IFontData embedded in embeddedFonts)
            {
                if (embedded.Equals(font))
                {
                    alreadyEmbedded = true;
                    break;
                }
            }

            if (!alreadyEmbedded)
            {
                presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
            }
        }

        // Save the updated presentation
        presentation.Save("AddEmbeddedFont_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}