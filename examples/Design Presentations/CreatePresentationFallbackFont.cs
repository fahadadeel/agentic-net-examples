using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesFallbackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths (adjust as needed)
            string dataDir = "C:\\SlidesData\\";
            string inputFile = dataDir + "input.pptx";
            string outputFile = dataDir + "output.pptx";
            string outputImage = dataDir + "slide1.png";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile);

            // Create a new fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            // Add fallback rules for specific Unicode ranges
            rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            rules.Add(new Aspose.Slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho"));

            // Add fallback rule for emoji characters
            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Apple Color Emoji", "Noto Color Emoji" };
            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, emojiFonts));

            // Assign the fallback rules to the presentation's FontsManager
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Render the first slide to an image and save it
            Aspose.Slides.IImage img = pres.Slides[0].GetImage(1f, 1f);
            img.Save(outputImage, Aspose.Slides.ImageFormat.Png);
            img.Dispose();

            // Save the modified presentation
            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}