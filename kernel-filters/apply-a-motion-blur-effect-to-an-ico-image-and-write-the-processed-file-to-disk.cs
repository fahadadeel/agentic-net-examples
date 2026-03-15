using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

public class Program
{
    static void Main(string[] args)
    {
        // Input ICO file and output processed image path
        string inputPath = "input.ico";
        string outputPath = "output.png";

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Motion blur parameters
            int kernelSize = 9;          // Must be an odd number
            double angleDegrees = 45.0;  // Angle in degrees

            // Generate motion blur kernel
            double[,] kernel = ConvolutionFilter.GetBlurMotion(kernelSize, angleDegrees);

            // Apply motion blur filter to the entire image
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

            // Save the processed image as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}