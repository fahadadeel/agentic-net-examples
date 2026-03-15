using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class RasterToSvgConverter
{
    static void Main()
    {
        // Input raster image path (e.g., PNG, JPEG, BMP)
        string inputPath = @"C:\Images\sample.png";

        // Output SVG file path
        string outputPath = @"C:\Images\sample_converted.svg";

        // Load the raster image using Aspose.Imaging's unified loader
        using (Image rasterImage = Image.Load(inputPath))
        {
            // Prepare rasterization options: set the page size to match the source image dimensions
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = rasterImage.Size
            };

            // Configure SVG save options and attach the rasterization settings
            SvgOptions saveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // Optional: render text as shapes for better compatibility
                TextAsShapes = true
            };

            // Save the image as SVG using the configured options
            rasterImage.Save(outputPath, saveOptions);
        }

        Console.WriteLine("Raster image successfully converted to SVG.");
    }
}