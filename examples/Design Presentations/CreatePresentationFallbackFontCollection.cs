using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the fonts manager (read‑only property)
        Aspose.Slides.IFontsManager fontsManager = presentation.FontsManager;

        // Retrieve the current fallback rules collection
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = fontsManager.FontFallBackRulesCollection;

        // Add a fallback rule for a Unicode range (example: Cyrillic characters)
        fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Times New Roman"));

        // Assign the modified collection back to the manager (optional if same instance)
        fontsManager.FontFallBackRulesCollection = fallbackRules;

        // Save the presentation before exiting
        presentation.Save("FallbackFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}