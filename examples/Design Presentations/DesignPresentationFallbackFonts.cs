using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Retrieve the fallback font rules collection from the FontsManager
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

        // Add a fallback rule: for Unicode range 0x400-0x4FF use "Times New Roman"
        fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

        // Save the presentation to a file
        presentation.Save("FallbackFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}