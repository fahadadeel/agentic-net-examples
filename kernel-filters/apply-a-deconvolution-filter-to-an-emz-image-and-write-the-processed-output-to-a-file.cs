using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input EMZ (compressed EMF) file path
        string inputPath = "input.emz";
        // Output raster image path after applying deconvolution filter
        string outputPath = "output.png";

        // Load the EMZ image as a vector image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for converting vector to raster
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = vectorImage.Size,
                BackgroundColor = Color.White
            };

            // Rasterize the vector image into a memory stream as PNG
            using (MemoryStream rasterStream = new MemoryStream())
            {
                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                vectorImage.Save(rasterStream, pngSaveOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                {
                    // Define a simple deconvolution kernel (sharpen-like)
                    double[] kernel = new double[]
                    {
                        0.0, -1.0, 0.0,
                        -1.0, 5.0, -1.0,
                        0.0, -1.0, 0.0
                    };

                    // Apply the deconvolution filter to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new DeconvolutionFilterOptions(kernel));

                    // Save the processed image to the output file
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}