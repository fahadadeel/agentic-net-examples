using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input ICO file path
        string inputPath = "input.ico";
        // Output ICO file path
        string outputPath = "output.ico";

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a deconvolution filter (Gauss-Wiener) to the entire image
            // Parameters: radius = 5, sigma = 4.0
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}