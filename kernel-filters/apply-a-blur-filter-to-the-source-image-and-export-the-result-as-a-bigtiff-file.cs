using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output images
        string inputPath = "input.png";
        string outputPath = "output.tif";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply a Gaussian blur filter (radius: 5, sigma: 4.0) to the entire image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Configure BigTIFF saving options
            var bigTiffOptions = new BigTiffOptions(TiffExpectedFormat.BigTiffDeflateRgb);

            // Save the processed image as a BigTIFF file
            raster.Save(outputPath, bigTiffOptions);
        }
    }
}