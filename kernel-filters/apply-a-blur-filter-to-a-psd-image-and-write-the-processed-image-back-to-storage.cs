using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (use arguments if provided)
        string inputPath = args.Length > 0 ? args[0] : "input.psd";
        string outputPath = args.Length > 1 ? args[1] : "output.psd";

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply a Gaussian blur filter (radius: 5, sigma: 4.0) to the entire image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Prepare PSD save options (default settings)
            PsdOptions saveOptions = new PsdOptions();

            // Save the processed image back to PSD format
            raster.Save(outputPath, saveOptions);
        }
    }
}