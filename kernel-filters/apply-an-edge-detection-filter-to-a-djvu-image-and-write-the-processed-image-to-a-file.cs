using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class EdgeDetectionExample
{
    static void Main()
    {
        // Path to the source DJVU image
        string inputPath = @"C:\temp\sample.djvu";

        // Path where the processed image will be saved
        string outputPath = @"C:\temp\sample.EdgeDetected.png";

        // Load the DJVU image using the Aspose.Imaging load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to DjvuImage to access DJVU‑specific functionality
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply an edge‑like effect.
            // Aspose.Imaging does not provide a dedicated edge detection filter,
            // so we use a Sharpen filter as a close approximation.
            // The filter is applied to the whole image (djvuImage.Bounds).
            djvuImage.Filter(
                djvuImage.Bounds,
                new SharpenFilterOptions(kernelSize: 5, sigma: 4.0));

            // Save the processed image using the Aspose.Imaging save rule.
            // The image is saved as PNG; any supported format can be used.
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}