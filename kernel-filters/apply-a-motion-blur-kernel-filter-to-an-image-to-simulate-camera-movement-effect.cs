using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output_motion_blur.jpg";

        // Load the image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a motion blur (motion wiener) filter:
            // Length = 15, smooth factor = 1.0, angle = 45 degrees
            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(15, 1.0, 45.0));

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}