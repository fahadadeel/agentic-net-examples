using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class EdgeDetectionExample
{
    static void Main()
    {
        // Path to the source image
        string inputPath = @"c:\temp\sample.png";

        // Path to the output image
        string outputPath = @"c:\temp\sample.EdgeDetected.png";

        // Load the image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter (which emphasizes edges) to the whole image.
            // SharpenFilterOptions takes kernel size and sigma; a 3x3 kernel is typical for edge emphasis.
            SharpenFilterOptions sharpenOptions = new SharpenFilterOptions(3, 1.0);

            // Apply the filter to the entire image bounds
            rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

            // Save the processed image using Aspose.Imaging's save rule
            rasterImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
        }
    }
}