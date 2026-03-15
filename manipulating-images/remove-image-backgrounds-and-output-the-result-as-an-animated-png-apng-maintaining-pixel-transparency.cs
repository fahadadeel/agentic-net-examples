using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output.apng";

        // Load the source image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure auto‑masking options (GraphCut with default strokes)
            var maskingOptions = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform masking
            var masking = new Aspose.Imaging.Masking.ImageMasking(sourceImage);
            using (Aspose.Imaging.Masking.Result.MaskingResult results = masking.Decompose(maskingOptions))
            {
                // Retrieve the foreground (masked object) image
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    // Save the result as an animated PNG (single‑frame APNG)
                    foreground.Save(outputPath, new ApngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
                }
            }
        }
    }
}