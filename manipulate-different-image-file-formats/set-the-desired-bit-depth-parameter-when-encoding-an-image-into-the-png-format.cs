using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class SetPngBitDepth
{
    static void Main()
    {
        // Path to the source image (any supported format)
        string sourcePath = @"c:\temp\input.png";

        // Path for the resulting PNG image
        string outputPath = @"c:\temp\output_8bit.png";

        // Load the source image
        using (Image image = Image.Load(sourcePath))
        {
            // Create PNG save options
            PngOptions pngOptions = new PngOptions();

            // Desired bit depth (allowed values: 1, 2, 4, 8, 16)
            pngOptions.BitDepth = 8;

            // Set a compatible color type for the chosen bit depth
            // TruecolorWithAlpha supports 8 and 16 bits per channel
            pngOptions.ColorType = PngColorType.TruecolorWithAlpha;

            // Optional: set maximum compression (0‑9)
            pngOptions.CompressionLevel = 9;

            // Save the image using the configured PNG options
            image.Save(outputPath, pngOptions);
        }
    }
}