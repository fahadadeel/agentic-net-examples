using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BigTiffToSvgConverter
{
    static void Main()
    {
        // Path to the source BIGTIFF image
        string inputPath = @"C:\Images\source_big.tif";

        // Desired output SVG file path
        string outputPath = @"C:\Images\converted.svg";

        // Load the BIGTIFF image (Aspose.Imaging automatically creates a BigTiffImage instance)
        using (Image bigTiff = Image.Load(inputPath))
        {
            // Configure vector rasterization options – page size matches the source image dimensions
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = bigTiff.Size
            };

            // Create SVG save options and attach the rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save the raster image as an SVG vector representation
            bigTiff.Save(outputPath, svgOptions);
        }
    }
}