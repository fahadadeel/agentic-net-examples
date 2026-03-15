using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths for the source TIFF and the output image
        string inputPath = @"C:\Temp\sample.tif";
        string outputPath = @"C:\Temp\sample.GaussianBlur.png";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access TIFF‑specific methods
            TiffImage tiffImage = (TiffImage)image;

            // Apply Gaussian blur to the whole image (radius = 5, sigma = 4.0)
            tiffImage.Filter(
                tiffImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image (here as PNG, but any supported format can be used)
            tiffImage.Save(outputPath, new PngOptions());
        }
    }
}