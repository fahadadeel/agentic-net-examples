using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input ICO file path
        string inputPath = "input.ico";
        // Output PNG file path
        string outputPath = "output.png";

        // Prepare PNG save options with a file create source
        Source outSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = outSource };

        // Load the ICO image, apply a sharpen (edge detection) filter, and save the result
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
            raster.Save(outputPath, pngOptions);
        }
    }
}