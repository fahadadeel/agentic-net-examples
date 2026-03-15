using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class EmbossOdgExample
{
    static void Main()
    {
        // Input ODG file path
        string inputPath = @"C:\Images\sample.odg";

        // Output file path (PNG format)
        string outputPath = @"C:\Images\sample_embossed.png";

        // Load the ODG image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to OdgImage to access ODG‑specific members
            OdgImage odgImage = (OdgImage)image;

            // Apply an emboss filter to the whole image area
            odgImage.Filter(
                odgImage.Bounds,                     // Target rectangle (entire image)
                new EmbossFilterOptions()            // Emboss filter options (default parameters)
            );

            // Save the processed image to a new file (PNG format)
            odgImage.Save(outputPath, new PngOptions());
        }
    }
}