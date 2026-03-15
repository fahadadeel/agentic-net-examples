using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class GaussianBlurExample
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample.GaussianBlur.png";

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Create Gaussian blur filter options:
            // size = 5 (kernel size), sigma = 4.0 (smoothing factor)
            var gaussianOptions = new GaussianBlurFilterOptions(5, 4.0);

            // Apply the filter to the entire image bounds
            rasterImage.Filter(rasterImage.Bounds, gaussianOptions);

            // Save the processed image as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}