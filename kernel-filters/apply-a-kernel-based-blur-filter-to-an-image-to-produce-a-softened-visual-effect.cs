using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats;

// Load the source image
string inputPath = "input.jpg";
string outputPath = "output.jpg";

using (Image image = Image.Load(inputPath))
{
    // Cast to RasterImage to access filtering capabilities
    RasterImage rasterImage = (RasterImage)image;

    // Define a Gaussian blur filter with kernel size 5 and sigma 2.0
    var blurOptions = new GaussianBlurFilterOptions(5, 2.0);

    // Apply the blur filter to the entire image bounds
    rasterImage.Filter(rasterImage.Bounds, blurOptions);

    // Save the processed image
    rasterImage.Save(outputPath);
}