using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG file path (default if not provided)
        string sourcePath = args.Length > 0 ? args[0] : "input.png";
        // Output PNG file path (default if not provided)
        string outputPath = args.Length > 1 ? args[1] : "output_compressed.png";

        // Load the source image
        using (Image image = Image.Load(sourcePath))
        {
            // Configure PNG compression options
            var options = new PngOptions
            {
                // Maximum lossless compression (0-9)
                CompressionLevel = 9,
                // Adaptive filter provides best compression for most images
                FilterType = PngFilterType.Adaptive,
                // Enable progressive loading (optional)
                Progressive = true,
                // Preserve full color with alpha channel
                ColorType = PngColorType.TruecolorWithAlpha,
                // Standard 8‑bit per channel depth
                BitDepth = 8
            };

            // Save the image with the specified compression options
            image.Save(outputPath, options);
        }
    }
}