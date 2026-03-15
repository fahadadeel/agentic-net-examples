using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.png";
        string outputPath = "output_sharpen.png";

        // Load the image and cast it to RasterImage for filtering
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a sharpen filter with kernel size 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the filtered image
            raster.Save(outputPath);
        }
    }
}