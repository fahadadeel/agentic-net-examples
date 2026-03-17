using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToTiffConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input file path and output TIFF file path
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: SlideToTiffConverter <input-ppt-or-pptx> <output-tiff>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            try
            {
                // Load the presentation (supports PPT and PPTX)
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure high‑resolution TIFF options
                    TiffOptions tiffOptions = new TiffOptions();
                    tiffOptions.DpiX = 300; // Horizontal DPI
                    tiffOptions.DpiY = 300; // Vertical DPI

                    // Save the presentation as a multi‑page TIFF image
                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during conversion:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}