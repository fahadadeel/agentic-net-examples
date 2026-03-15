using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input EPS file path
        string inputPath = args.Length > 0 ? args[0] : "input.eps";
        // Output raster image path (PNG format)
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the EPS image
        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
        {
            // Prepare rasterization options to convert EPS to raster (PNG)
            var rasterOptions = new PngOptions
            {
                VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                }
            };

            // Rasterize EPS into a memory stream
            using (var memoryStream = new MemoryStream())
            {
                epsImage.Save(memoryStream, rasterOptions);
                memoryStream.Position = 0;

                // Load the rasterized image as RasterImage
                using (var rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Apply sharpen filter to the entire image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                    // Save the processed image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}