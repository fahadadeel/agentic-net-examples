using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (can be passed as arguments)
        string inputPath = args.Length > 0 ? args[0] : "input.tif";
        string outputPath = args.Length > 1 ? args[1] : "output.tif";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Check if the loaded image supports multiple pages
            if (image is IMultipageImage multipageImage)
            {
                // Iterate through each page and apply edits
                foreach (Image page in multipageImage.Pages)
                {
                    RasterImage raster = (RasterImage)page;
                    if (!raster.IsCached)
                        raster.CacheData();

                    // Example edits: increase brightness and rotate slightly
                    raster.AdjustBrightness(20);                     // brighten
                    raster.Rotate(5.0f, true, Color.White);          // rotate 5 degrees, resize canvas, white background
                }

                // Save the modified multipage image as TIFF
                TiffOptions options = new TiffOptions(TiffExpectedFormat.TiffJpegRgb);
                image.Save(outputPath, options);
            }
            else
            {
                Console.WriteLine("The loaded image is not a multipage image.");
            }
        }
    }
}