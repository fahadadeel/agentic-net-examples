using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (provide via command line or use defaults)
        string inputPath = args.Length > 0 ? args[0] : "input.tif";
        string outputPath = args.Length > 1 ? args[1] : "output_compressed.tif";

        // Load the existing TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure lossless compression (LZW) and predictor for better size reduction
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Predictor = TiffPredictor.Horizontal;

            // Save the image with the specified TIFF options
            image.Save(outputPath, tiffOptions);
        }

        Console.WriteLine($"Compressed TIFF saved to: {outputPath}");
    }
}