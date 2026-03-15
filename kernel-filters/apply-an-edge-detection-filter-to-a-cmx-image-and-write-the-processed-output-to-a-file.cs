using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input CMX, temporary rasterized PNG, and final output
        string inputCmxPath = "input.cmx";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the CMX vector image and rasterize it to PNG
        using (CmxImage cmx = (CmxImage)Image.Load(inputCmxPath))
        {
            Source pngSource = new FileCreateSource(tempPngPath, false);
            PngOptions pngOptions = new PngOptions() { Source = pngSource };
            cmx.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply edge detection, and save the result
        using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
        {
            // Define a simple Laplacian edge detection kernel
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Create convolution filter options with the kernel
            ConvolutionFilterOptions convOptions = new ConvolutionFilterOptions(kernel);

            // Apply the filter to the entire image
            raster.Filter(raster.Bounds, convOptions);

            // Save the processed image
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions outOptions = new PngOptions() { Source = outSource };
            raster.Save(outputPath, outOptions);
        }

        // Clean up the temporary PNG file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}