using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input ICO file path
        string inputPath = "input.ico";
        // Output JPG file path (ICO format not supported for saving, fallback to JPG)
        string outputPath = "output.jpg";

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with kernel size 5 and sigma 4.0 to the whole image
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as JPG
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };
            rasterImage.Save(outputPath, jpegOptions);
        }
    }
}