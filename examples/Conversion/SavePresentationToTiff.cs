using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string inputPath = "input.pptx";
            // Path where the TIFF file will be saved
            string outputPath = "output.tiff";

            // Load the presentation from the PPTX file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Save the presentation as a multi‑page TIFF image
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff);

            // Release resources
            presentation.Dispose();
        }
    }
}