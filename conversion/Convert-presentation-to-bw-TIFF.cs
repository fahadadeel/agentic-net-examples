using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToBWTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PowerPoint file
                string inputPath = "input.pptx";
                // Output TIFF file
                string outputPath = "output.tiff";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure TIFF options for black‑and‑white conversion
                    TiffOptions options = new TiffOptions();
                    options.CompressionType = TiffCompressionTypes.CCITT4;
                    options.BwConversionMode = BlackWhiteConversionMode.Dithering;

                    // Save as multi‑page TIFF with the specified options
                    presentation.Save(outputPath, SaveFormat.Tiff, options);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during conversion
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}