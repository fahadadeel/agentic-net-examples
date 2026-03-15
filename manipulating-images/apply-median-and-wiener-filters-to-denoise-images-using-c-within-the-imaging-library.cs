using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.png");
        string medianOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.median.png");
        string wienerOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.wiener.png");

        // Apply Median filter
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
            raster.Save(medianOutputPath);
        }

        // Apply Gauss-Wiener filter
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));
            raster.Save(wienerOutputPath);
        }
    }
}