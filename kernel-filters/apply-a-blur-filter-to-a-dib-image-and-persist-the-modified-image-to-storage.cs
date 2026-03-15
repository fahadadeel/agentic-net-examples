using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source DIB image
        string inputPath = @"C:\Temp\sample.dib";

        // Path for the output image (PNG format)
        string outputPath = @"C:\Temp\sample_blurred.png";

        // Load the DIB image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gaussian blur filter to the entire image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the modified image in PNG format
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}