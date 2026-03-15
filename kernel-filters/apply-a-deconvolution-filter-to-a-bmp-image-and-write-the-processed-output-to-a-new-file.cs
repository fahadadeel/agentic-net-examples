using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input BMP file path
        string inputPath = "input.bmp";
        // Output BMP file path
        string outputPath = "output_deconvolved.bmp";

        // Load the BMP image as a RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a Gauss-Wiener deconvolution filter to the entire image
            // Parameters: radius = 5, sigma = 4.0
            raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image as BMP
            raster.Save(outputPath, new BmpOptions());
        }
    }
}