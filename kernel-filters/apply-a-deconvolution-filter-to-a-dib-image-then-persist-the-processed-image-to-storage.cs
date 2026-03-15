using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input DIB (BMP) image and output image
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Load the DIB image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply a Gauss-Wiener deconvolution filter (radius=5, sigma=4.0)
            var deconvFilter = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0);
            raster.Filter(raster.Bounds, deconvFilter);

            // Prepare BMP save options with a file source
            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the processed image
            raster.Save(outputPath, bmpOptions);
        }
    }
}