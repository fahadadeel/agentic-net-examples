using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Input image (any supported format) – this demonstrates the conversion source.
        string inputPath = @"c:\temp\input.jpg";

        // Output PNG file path.
        string outputPath = @"c:\temp\output.png";

        // Load the source image using Aspose.Imaging's Load method (lifecycle rule).
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Create PNG options – constructor provided by the API (lifecycle rule).
            PngOptions pngOptions = new PngOptions();

            // -----------------------------------------------------------------
            // Enumerating PNG input parameters that influence the conversion.
            // -----------------------------------------------------------------

            // BitDepth – allowed values: 1, 2, 4, 8, 16.
            pngOptions.BitDepth = 8;

            // ColorType – defines the PNG color model (e.g., Grayscale, Truecolor, etc.).
            pngOptions.ColorType = PngColorType.TruecolorWithAlpha;

            // PngCompressionLevel – compression intensity (0 = none, 9 = maximum).
            pngOptions.PngCompressionLevel = 9;

            // FilterType – PNG filter applied during saving.
            pngOptions.FilterType = PngFilterType.Adaptive;

            // Progressive – enables progressive (interlaced) PNG.
            pngOptions.Progressive = true;

            // KeepMetadata – retains original image metadata in the PNG.
            pngOptions.KeepMetadata = true;

            // FullFrame – indicates whether the full frame should be saved.
            pngOptions.FullFrame = false;

            // BufferSizeHint – optional hint for internal buffer size (example value).
            pngOptions.BufferSizeHint = 1024 * 1024; // 1 MB

            // -----------------------------------------------------------------
            // Save the image as PNG using the configured options (lifecycle rule).
            // -----------------------------------------------------------------
            sourceImage.Save(outputPath, pngOptions);
        }
    }
}