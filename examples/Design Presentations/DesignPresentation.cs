using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string presentationPath = "output.pptx";
            string imagePath = "slide1.png";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Create fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            // Add a fallback rule for Unicode range 0x400-0x4FF using Times New Roman
            rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

            // Assign the rules to the presentation's FontsManager
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            pres.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Render the first slide to an image
            Aspose.Slides.IImage img = pres.Slides[0].GetImage(1f, 1f);
            img.Save(imagePath, Aspose.Slides.ImageFormat.Png);
            img.Dispose();

            // Clean up
            pres.Dispose();
        }
    }
}