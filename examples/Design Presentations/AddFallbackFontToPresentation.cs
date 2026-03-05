using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the fallback rules collection from the FontsManager
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

        // Create a new fallback rule for a Unicode range with a primary font
        Aspose.Slides.IFontFallBackRule fallbackRule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Arial");

        // Add additional fallback fonts to the rule
        fallbackRule.AddFallBackFonts("Times New Roman");
        fallbackRule.AddFallBackFonts(new string[] { "Tahoma", "Verdana" });

        // Add the rule to the collection
        fallbackRules.Add(fallbackRule);

        // Save the presentation before exiting
        presentation.Save("FallbackFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}