using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output_edge.bmp";

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage raster = (RasterImage)image;

            // Define a simple edge detection kernel
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply the convolution filter with the edge detection kernel to the whole image
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

            // Save the processed image as BMP
            raster.Save(outputPath, new BmpOptions());
        }
    }
}