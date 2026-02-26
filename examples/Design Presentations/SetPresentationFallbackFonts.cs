using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the existing fallback rules collection
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

        // Add a fallback rule (example Unicode range for Cyrillic)
        fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

        // Save the presentation
        presentation.Save("FallbackFonts.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}