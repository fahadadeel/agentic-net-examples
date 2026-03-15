using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (can be passed as command‑line arguments)
        string inputPath = args.Length > 0 ? args[0] : "input.webp";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the WebP image
        using (WebPImage webpImage = new WebPImage(inputPath))
        {
            // Apply a Gauss‑Wiener deconvolution filter to the whole image
            webpImage.Filter(webpImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image as PNG
            webpImage.Save(outputPath, new PngOptions());
        }
    }
}