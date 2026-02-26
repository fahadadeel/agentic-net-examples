using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new empty presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Retrieve the collection of font fallback rules from the presentation's FontsManager
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

        // Define a new fallback rule for a specific Unicode range with a primary font
        Aspose.Slides.FontFallBackRule rule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman");

        // Add additional fallback fonts to the rule
        rule.AddFallBackFonts("Arial");
        rule.AddFallBackFonts(new string[] { "Tahoma", "Verdana" });

        // Add the configured rule to the collection
        fallbackRules.Add(rule);

        // Save the presentation to a file before exiting
        presentation.Save("FallbackFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}