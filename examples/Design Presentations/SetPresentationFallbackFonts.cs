using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Initialize a new fallback rules collection
                Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();

                // Add a fallback rule (example Unicode range to Times New Roman)
                fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                // Assign the collection to the presentation's FontsManager
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Save the presentation
                presentation.Save("FallbackFonts.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}