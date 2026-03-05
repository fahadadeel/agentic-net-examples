using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the fallback rules collection from the FontsManager
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

        // Create a new fallback rule for Unicode range 0x400-0x4FF with primary font "Times New Roman"
        Aspose.Slides.FontFallBackRule rule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman");

        // Add additional fallback fonts to the rule
        rule.AddFallBackFonts("Arial");
        rule.AddFallBackFonts(new string[] { "Calibri", "Verdana" });

        // Add the rule to the collection
        fallbackRules.Add(rule);

        // Save the presentation
        presentation.Save("FallbackFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}