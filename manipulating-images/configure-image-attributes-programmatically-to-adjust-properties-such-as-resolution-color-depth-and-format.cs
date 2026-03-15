using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
            return;

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access raster-specific methods
            RasterImage raster = (RasterImage)image;

            // Ensure image data is cached before modifications
            if (!raster.IsCached)
                raster.CacheData();

            // Adjust resolution to 300 DPI (horizontal and vertical)
            raster.SetResolution(300, 300);

            // Save the image in PNG format while preserving original bit depth
            var pngOptions = new PngOptions();
            raster.Save(outputPath, pngOptions);
        }
    }
}