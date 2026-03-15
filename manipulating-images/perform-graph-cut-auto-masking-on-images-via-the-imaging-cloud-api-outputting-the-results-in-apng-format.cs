using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths are taken from command‑line arguments.
        // args[0] – source image path, args[1] – destination APNG path.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: ImageMaskingApng <inputImage> <outputApng>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the source image as a RasterImage.
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure auto‑masking with GraphCut algorithm.
            var maskingOptions = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                // Export options are required but we use a StreamSource to avoid temporary files.
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform the masking operation.
            using (MaskingResult result = new ImageMasking(sourceImage).Decompose(maskingOptions))
            // Retrieve the foreground (object) image – index 1 holds the foreground.
            using (RasterImage foreground = (RasterImage)result[1].GetImage())
            {
                // Save the foreground as an animated PNG (APNG).
                foreground.Save(outputPath, new ApngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 200, // milliseconds per frame
                    NumPlays = 0             // 0 = infinite loop
                });
            }
        }
    }
}