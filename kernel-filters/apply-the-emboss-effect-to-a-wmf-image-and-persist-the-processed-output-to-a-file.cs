using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputPath = "input.wmf";
        // Output raster image path (PNG)
        string outputPath = "output.png";

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Obtain vector rasterization options for converting WMF to raster
            var vectorOptions = (VectorRasterizationOptions)wmfImage.GetDefaultOptions(
                new object[] { Color.White, wmfImage.Width, wmfImage.Height });

            // Prepare PNG options with the vector rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Rasterize the WMF into a memory stream
            using (var memoryStream = new MemoryStream())
            {
                wmfImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImageContainer = Image.Load(memoryStream))
                {
                    var rasterImage = (RasterImage)rasterImageContainer;

                    // Apply Emboss effect using a predefined convolution kernel
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save the processed image to the output file
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}