using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class TiffToSvgConverter
{
    static void Main()
    {
        // Path to the source TIFF image
        string inputPath = @"C:\Images\source.tif";

        // Desired output SVG file path
        string outputPath = @"C:\Images\converted.svg";

        // Load the TIFF image using Aspose.Imaging's lifecycle method
        using (Image tiffImage = Image.Load(inputPath))
        {
            // Configure rasterization options: set the page size to match the source image dimensions
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = tiffImage.Size
            };

            // Create SVG save options and attach the rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the loaded TIFF as an SVG vector graphic while preserving visual fidelity
            tiffImage.Save(outputPath, svgOptions);
        }
    }
}