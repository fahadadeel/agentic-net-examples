using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths for input CMX, intermediate PNG, and final output PNG
        string inputCmxPath = @"c:\temp\sample.cmx";
        string intermediatePngPath = @"c:\temp\sample_intermediate.png";
        string outputPngPath = @"c:\temp\sample_gaussian_blur.png";

        // Load the CMX image
        using (Image cmxImage = Image.Load(inputCmxPath))
        {
            // Save the CMX image as a PNG to obtain a raster representation
            cmxImage.Save(intermediatePngPath, new PngOptions());
        }

        // Load the intermediate PNG as a RasterImage
        using (Image image = Image.Load(intermediatePngPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur filter to the whole image (radius 5, sigma 4.0)
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image to the final output path
            rasterImage.Save(outputPngPath);
        }
    }
}