using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Input DJVU file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "sample.djvu";
        // Output PNG file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "sample_blur.png";

        // Load the DJVU image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DjvuImage to access DJVU-specific methods
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply Gaussian blur to the entire image (radius 5, sigma 4.0)
            djvuImage.Filter(
                djvuImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}