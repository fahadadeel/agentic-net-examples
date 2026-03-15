using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths. Use arguments if provided, otherwise default paths.
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output_blur.png";

        // Load the PNG image.
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel manipulation.
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image.
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG.
            raster.Save(outputPath);
        }
    }
}