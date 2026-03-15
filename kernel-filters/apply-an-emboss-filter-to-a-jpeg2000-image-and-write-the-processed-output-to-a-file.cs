using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG2000 file path
        string inputPath = "input.jp2";
        // Output JPEG2000 file path
        string outputPath = "output.jp2";

        // Load the JPEG2000 image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply emboss filter using a predefined convolution kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Prepare JPEG2000 save options
            Jpeg2000Options saveOptions = new Jpeg2000Options();

            // Save the processed image as JPEG2000
            image.Save(outputPath, saveOptions);
        }
    }
}