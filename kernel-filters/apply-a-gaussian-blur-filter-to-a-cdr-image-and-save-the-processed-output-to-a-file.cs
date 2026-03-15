using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input CDR file path and output raster file path
        string inputPath = args.Length > 0 ? args[0] : "input.cdr";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the CDR vector image
        using (Aspose.Imaging.FileFormats.Cdr.CdrImage cdrImage = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Image.Load(inputPath))
        {
            // Save the vector image to a memory stream as PNG (raster format)
            using (MemoryStream rasterStream = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions();
                cdrImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                {
                    // Apply Gaussian blur filter (radius 5, sigma 4.0) to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed raster image to the specified output path
                    PngOptions outOptions = new PngOptions();
                    rasterImage.Save(outputPath, outOptions);
                }
            }
        }
    }
}