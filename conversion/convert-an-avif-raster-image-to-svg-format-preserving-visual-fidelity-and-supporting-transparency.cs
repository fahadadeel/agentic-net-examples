using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class AvifToSvgConverter
{
    static void Main()
    {
        // Path to the source AVIF image
        string inputFile = @"C:\Images\sample.avif";

        // Desired output SVG file path
        string outputFile = @"C:\Images\sample.svg";

        // Load the AVIF image using Aspose.Imaging's generic Image loader.
        // The loader automatically creates an AvifImage instance internally.
        using (Image avifImage = Image.Load(inputFile))
        {
            // Configure rasterization options for SVG output.
            // PageSize is set to the original image size to preserve dimensions.
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = avifImage.Size
                // No background color is set, so transparency is retained.
            };

            // Create SVG save options and attach the rasterization settings.
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // KeepMetadata = true; // optional: preserve original metadata
                // Compress = false;   // optional: do not compress the SVG output
            };

            // Save the loaded AVIF image as an SVG file, preserving visual fidelity and transparency.
            avifImage.Save(outputFile, svgOptions);
        }
    }
}