using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenBmpExample
{
    static void Main()
    {
        // Define the folder containing the source BMP and the output path
        string dataDir = @"C:\Images\";

        // Load the BMP image
        using (Image image = Image.Load(dataDir + "source.bmp"))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter to the entire image.
            // Kernel size = 5, sigma = 4.0 (adjust as needed)
            rasterImage.Filter(
                rasterImage.Bounds,
                new SharpenFilterOptions(5, 4.0));

            // Save the processed image as a new BMP file
            rasterImage.Save(dataDir + "sharpened.bmp");
        }
    }
}