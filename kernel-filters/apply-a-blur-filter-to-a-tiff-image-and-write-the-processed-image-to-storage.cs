using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\temp\sample.tif";
        string outputPath = @"C:\temp\sample.GaussianBlur.tif";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access the Filter method
            var tiffImage = (Aspose.Imaging.FileFormats.Tiff.TiffImage)image;

            // Apply Gaussian blur filter to the entire image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            tiffImage.Filter(
                tiffImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back to TIFF format
            tiffImage.Save(outputPath, new TiffOptions(tiffImage.FileFormat));
        }
    }
}