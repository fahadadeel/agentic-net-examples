using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

string inputPath = @"C:\Images\sample.jp2";      // Path to the source JPEG2000 image
string outputPath = @"C:\Images\sample_edge.png"; // Path for the processed image

// Load the JPEG2000 image
using (Image image = Image.Load(inputPath))
{
    // Cast to RasterImage to gain access to the Filter method
    RasterImage rasterImage = (RasterImage)image;

    // Apply an edge‑enhancing filter (Sharpen filter used as a proxy for edge detection)
    // Rectangle covering the whole image and SharpenFilterOptions with kernel size 5 and sigma 4.0
    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

    // Save the processed image as PNG
    rasterImage.Save(outputPath, new PngOptions());
}