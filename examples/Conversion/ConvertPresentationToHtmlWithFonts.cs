using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PowerPoint presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Embed all fonts used in the presentation
        Aspose.Slides.IFontsManager fontsManager = presentation.FontsManager;
        Aspose.Slides.IFontData[] allFonts = fontsManager.GetFonts();
        for (int i = 0; i < allFonts.Length; i++)
        {
            Aspose.Slides.IFontData font = allFonts[i];
            // Embed the font with all characters
            fontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
        }

        // Set HTML export options (optional: specify default font)
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
        htmlOptions.DefaultRegularFont = "Arial";

        // Save the presentation as HTML with linked fonts
        presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
    }
}