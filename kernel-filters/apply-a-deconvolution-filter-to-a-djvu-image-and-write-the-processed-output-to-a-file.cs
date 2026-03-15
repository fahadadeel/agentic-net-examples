using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input DJVU image and output PNG image
        string inputPath = "sample.djvu";
        string outputPath = "sample_deconvolved.png";

        // Load the DJVU image
        using (Image image = Image.Load(inputPath))
        {
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply a deconvolution filter (Gauss-Wiener) to the entire image
            djvuImage.Filter(
                djvuImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0)
            );

            // Save the processed image as PNG
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}