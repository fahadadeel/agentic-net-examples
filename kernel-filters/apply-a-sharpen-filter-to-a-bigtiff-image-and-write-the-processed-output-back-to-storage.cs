using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main()
    {
        // Path to the source BigTIFF image
        string inputPath = @"C:\Images\source.bigtiff";

        // Path where the processed image will be saved
        string outputPath = @"C:\Images\sharpened.bigtiff";

        // Load the image using Aspose.Imaging's load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to BigTiffImage to access TIFF-specific functionality
            BigTiffImage bigTiff = (BigTiffImage)image;

            // Apply a sharpen filter to the entire image.
            // SharpenFilterOptions takes kernel size (int) and sigma (double).
            bigTiff.Filter(
                bigTiff.Bounds,                                   // Rectangle covering the whole image
                new SharpenFilterOptions(5, 4.0)                 // Kernel size = 5, Sigma = 4.0
            );

            // Save the processed image back to storage using the built‑in Save method
            bigTiff.Save(outputPath);
        }
    }
}