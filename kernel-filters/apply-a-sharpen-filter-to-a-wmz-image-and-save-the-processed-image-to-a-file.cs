using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class ApplySharpenToWmz
{
    static void Main()
    {
        // Input WMZ file path
        string inputPath = @"C:\Images\sample.wmz";
        // Output PNG file path after applying sharpen filter
        string outputPath = @"C:\Images\sample_sharpened.png";

        // Load the WMZ image (vector format)
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Rasterize the vector image to a raster format (PNG) in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Set up PNG options with vector rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        PageSize = vectorImage.Size // preserve original size
                    }
                };

                // Save the rasterized image to the memory stream
                vectorImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // reset stream position for reading

                // Load the rasterized image from the memory stream
                using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                {
                    // Apply sharpen filter to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the processed image to the desired output file
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}