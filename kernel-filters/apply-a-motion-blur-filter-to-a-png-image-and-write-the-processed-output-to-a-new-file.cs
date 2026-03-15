using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using System.Drawing;

class MotionBlurExample
{
    static void Main()
    {
        // Input PNG file path
        string inputPath = @"C:\temp\input.png";

        // Output PNG file path
        string outputPath = @"C:\temp\output_motion_blur.png";

        // Load the image using Aspose.Imaging's Image.Load (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a motion blur (motion wiener) filter to the whole image.
            // Parameters: length = 10, sigma = 1.0, angle = 0 degrees.
            rasterImage.Filter(
                rasterImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 0.0));

            // Save the processed image as PNG (lifecycle rule)
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}