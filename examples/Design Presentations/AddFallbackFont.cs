using System;
using System.IO;

namespace AddFallbackFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the external font file
            string fontPath = "C:\\fonts\\MyFont.ttf";
            // Path where the presentation will be saved
            string outputPath = "C:\\output\\FallbackDemo.pptx";

            // Load the font data from the file
            byte[] fontData = System.IO.File.ReadAllBytes(fontPath);
            // Register the external font with Aspose.Slides
            Aspose.Slides.FontsLoader.LoadExternalFont(fontData);

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Create a fallback rule for a Unicode range using the loaded font
            Aspose.Slides.IFontFallBackRule fallbackRule = new Aspose.Slides.FontFallBackRule(0x0u, 0xFFFFu, "MyFont");
            // Optionally add additional fallback fonts
            // fallbackRule.AddFallBackFonts("AnotherFont");

            // Create a collection and add the rule
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
            fallbackRules.Add(fallbackRule);

            // Assign the collection to the presentation's FontsManager
            pres.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clear the font cache
            Aspose.Slides.FontsLoader.ClearCache();

            // Dispose the presentation
            pres.Dispose();
        }
    }
}