using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input DIB (BMP) image path
        string inputPath = "input.dib";
        // Output image path (PNG format)
        string outputPath = "output.png";

        // Load the image and cast to RasterImage for filtering
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply motion blur filter: length=10, smooth=1.0, angle=45 degrees
            rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 45.0));

            // Save the processed image as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}