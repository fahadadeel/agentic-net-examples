using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DesignPresentations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output presentation paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Retrieve all embedded fonts
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            // List the names of embedded fonts
            foreach (Aspose.Slides.IFontData font in embeddedFonts)
            {
                Console.WriteLine(font.FontName);
            }

            // Save the presentation before exiting (required by authoring rules)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}