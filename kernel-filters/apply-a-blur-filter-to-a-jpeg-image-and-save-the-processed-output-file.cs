using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG file path
        string inputPath = "input.jpg";
        // Output JPEG file path
        string outputPath = "output.jpg";

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            rasterImage.Filter(rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Prepare JPEG save options (e.g., set quality)
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };

            // Save the processed image as JPEG
            rasterImage.Save(outputPath, jpegOptions);
        }
    }
}