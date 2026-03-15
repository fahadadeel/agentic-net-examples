using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output_edge.png";

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Define a simple edge detection kernel (Laplacian)
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 4, -1 },
                { 0, -1, 0 }
            };

            // Apply the convolution filter with the edge detection kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

            // Prepare PNG save options (optional settings)
            PngOptions pngOptions = new PngOptions
            {
                CompressionLevel = 6,
                FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive
            };

            // Save the processed image to a new PNG file
            image.Save(outputPath, pngOptions);
        }
    }
}