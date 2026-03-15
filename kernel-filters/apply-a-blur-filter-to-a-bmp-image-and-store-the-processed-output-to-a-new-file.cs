using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Paths for the source BMP image and the processed output
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Load the BMP image using Aspose.Imaging's lifecycle method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply a Gaussian blur filter to the entire image area
            // Radius = 5 pixels, Sigma = 4.0 (adjust as needed)
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image to a new BMP file using the appropriate save options
            raster.Save(outputPath, new BmpOptions());
        }
    }
}