using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConfigurePresentationFallbackFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputFile = "input.pptx";
            string outputPresentation = "output.pptx";
            string outputImage = "slide.png";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile);

            // Create a new fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            // Add a fallback rule for a Unicode range (example: Basic Latin)
            rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

            // Assign the fallback rules to the presentation's FontsManager
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Render the first slide to an image using default scaling
            Aspose.Slides.IImage img = pres.Slides[0].GetImage(1f, 1f);

            // Save the rendered image as PNG
            img.Save(outputImage, Aspose.Slides.ImageFormat.Png);
            img.Dispose();

            // Save the modified presentation
            pres.Save(outputPresentation, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}