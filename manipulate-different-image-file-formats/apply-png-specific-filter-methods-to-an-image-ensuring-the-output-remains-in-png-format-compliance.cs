using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG file path
        string inputPath = "input.png";
        // Output PNG file path
        string outputPath = "output.png";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Apply a Gaussian blur filter to the entire image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 2.0));

            // Configure PNG save options with a specific filter type
            PngOptions options = new PngOptions
            {
                // Use Adaptive filtering for best compression
                FilterType = PngFilterType.Adaptive,
                CompressionLevel = 9,
                // Preserve alpha channel
                ColorType = PngColorType.TruecolorWithAlpha,
                BitDepth = 8
            };

            // Save the processed image as PNG with the specified options
            raster.Save(outputPath, options);
        }
    }
}