using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Create a new fallback rules collection
        Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

        // Add fallback rules for specific Unicode ranges
        rules.Add(new Aspose.Slides.FontFallBackRule(0x400u, 0x4FFu, "Times New Roman"));
        rules.Add(new Aspose.Slides.FontFallBackRule(0x3040u, 0x309Fu, "MS Mincho"));

        // Add fallback rule for emoji range with multiple fonts
        string[] emojiFonts = new string[] { "Segoe UI Emoji", "Apple Color Emoji" };
        rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600u, 0x1F64Fu, emojiFonts));

        // Assign the collection to the presentation's FontsManager
        presentation.FontsManager.FontFallBackRulesCollection = rules;

        // Save the presentation
        presentation.Save("FallbackFonts.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}