using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Directory containing the source image
        string dir = @"c:\temp\";
        string inputPath = System.IO.Path.Combine(dir, "sample.png");

        // -------------------------------------------------
        // 1. Apply Median filter for basic noise reduction
        // -------------------------------------------------
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage raster = (RasterImage)image;

            // Median filter with a kernel size of 5 (odd size recommended)
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Save the result
            string medianPath = System.IO.Path.Combine(dir, "sample.MedianFilter.png");
            raster.Save(medianPath, new PngOptions());
        }

        // -------------------------------------------------
        // 2. Apply Gauss‑Wiener filter for advanced denoising
        //    while preserving image details
        // -------------------------------------------------
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Gauss‑Wiener filter with radius 5 and sigma 4.0
            // This filter performs deconvolution to reduce noise and retain edges
            raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the result
            string wienerPath = System.IO.Path.Combine(dir, "sample.GaussWienerFilter.png");
            raster.Save(wienerPath, new PngOptions());
        }
    }
}