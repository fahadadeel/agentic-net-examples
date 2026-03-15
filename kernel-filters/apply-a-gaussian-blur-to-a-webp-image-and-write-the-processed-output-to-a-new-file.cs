using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.webp";

        // Load the WebP image using the constructor that accepts a file path
        using (WebPImage webpImage = new WebPImage(inputPath))
        {
            // Apply Gaussian blur to the entire image.
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            webpImage.Filter(
                webpImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image to a new WebP file.
            // Using default WebPOptions; customize if required.
            webpImage.Save(outputPath, new WebPOptions());
        }
    }
}