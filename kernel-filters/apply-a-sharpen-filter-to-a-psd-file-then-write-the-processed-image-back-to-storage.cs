using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using System.Drawing;

string inputPath = "input.psd";   // Path to the source PSD file
string outputPath = "output.psd"; // Path where the processed PSD will be saved

// Load the PSD image
using (Image image = Image.Load(inputPath))
{
    // Cast to RasterImage to access raster-specific operations
    RasterImage rasterImage = (RasterImage)image;

    // Apply a sharpen filter to the entire image.
    // Parameters: kernel size = 5, sigma = 4.0
    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

    // Save the processed image back to storage
    rasterImage.Save(outputPath);
}