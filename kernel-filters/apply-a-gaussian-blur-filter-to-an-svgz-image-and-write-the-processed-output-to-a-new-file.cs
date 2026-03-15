using System;
using System.Drawing;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Input SVGZ file path
        string inputFile = @"D:\Compressed\example.svgz";
        // Output raster image (PNG) with Gaussian blur applied
        string outputFile = @"D:\Compressed\example_blurred.png";

        // Load the compressed SVGZ image
        using (Image vectorImage = Image.Load(inputFile))
        {
            // Prepare rasterization options to convert SVGZ to raster format
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            // Save the vector image to a memory stream as PNG (rasterized)
            using (var pngStream = new MemoryStream())
            {
                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };
                vectorImage.Save(pngStream, pngSaveOptions);
                pngStream.Position = 0; // Reset stream position for reading

                // Load the rasterized PNG from the memory stream
                using (Image rasterImage = Image.Load(pngStream))
                {
                    // Cast to RasterImage to access the Filter method
                    var raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur filter to the entire image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image to the output file
                    raster.Save(outputFile, new PngOptions());
                }
            }
        }
    }
}