using System;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPresentationPath = "input.pptx";
            string outputPresentationPath = "output.pptx";
            string outputImagePath = "slide1.png";

            // Create a collection of font fallback rules
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
            // Example rule: use Times New Roman for Unicode range 0x400-0x4FF
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPresentationPath);
            // Assign the fallback rules to the presentation's FontsManager
            presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Render the first slide to an image
            Aspose.Slides.IImage slideImage = presentation.Slides[0].GetImage(1f, 1f);
            // Save the rendered image as PNG
            slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
            slideImage.Dispose();

            // Save the presentation (required by authoring rules)
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            // Clean up resources
            presentation.Dispose();
        }
    }
}