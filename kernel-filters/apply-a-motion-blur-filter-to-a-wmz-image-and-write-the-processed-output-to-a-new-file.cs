using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class ApplyMotionBlurToWmz
{
    static void Main()
    {
        // Input WMZ (compressed WMF) file path
        string inputPath = "input.wmz";

        // Output file path (PNG format after applying the filter)
        string outputPath = "output.png";

        // Load the WMZ image. Aspose.Imaging.Image.Load works for all supported formats.
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Prepare rasterization options to convert the vector WMZ image to a raster image.
            // The page size is set to the original image size to preserve dimensions.
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size
            };

            // Define PNG save options that include the rasterization settings.
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Render the WMZ image into a raster image by saving it to a memory stream first.
            using (var memoryStream = new System.IO.MemoryStream())
            {
                // Render and store the rasterized image in the memory stream.
                wmfImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0; // Reset stream position for reading.

                // Load the rasterized image from the memory stream.
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    // Cast to RasterImage to gain access to the Filter method.
                    var raster = (RasterImage)rasterImage;

                    // Apply a motion Wiener filter (used here as a motion blur effect).
                    // Parameters: length = 10, smooth = 1.0, angle = 90 degrees.
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the processed raster image to the desired output file.
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}