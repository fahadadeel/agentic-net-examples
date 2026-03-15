using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input PSD file path
        string inputPath = "input.psd";
        // Output PSD file path
        string outputPath = "output.psd";

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0
            rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Prepare PSD save options
            PsdOptions psdOptions = new PsdOptions();

            // Save the blurred image as PSD
            rasterImage.Save(outputPath, psdOptions);
        }
    }
}