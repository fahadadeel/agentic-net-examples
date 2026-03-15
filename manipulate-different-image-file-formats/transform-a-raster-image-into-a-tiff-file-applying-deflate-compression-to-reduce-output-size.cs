using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        // Output TIFF path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.tif";

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Configure TIFF options with Deflate compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Compression = TiffCompressions.Deflate;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Save the image as TIFF using the configured options
            image.Save(outputPath, tiffOptions);
        }
    }
}