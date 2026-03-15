using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string initialOutputPath = "foreground_initial.png";
        string updatedOutputPath = "foreground_updated.png";

        // Load the source image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // ---------- First auto‑masking pass (calculate default strokes) ----------
            AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform masking
            using (MaskingResult firstResult = new ImageMasking(image).Decompose(options))
            {
                // Save the initial foreground result
                using (RasterImage foreground = (RasterImage)firstResult[1].GetImage())
                {
                    foreground.Save(initialOutputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            // ---------- Re‑use default strokes and add new points ----------
            // Retrieve the automatically calculated strokes
            Point[] defaultBackgroundStrokes = options.DefaultBackgroundStrokes;
            Point[] defaultForegroundStrokes = options.DefaultForegroundStrokes;

            // Extend background strokes with an additional point
            Point[] extendedBackgroundStrokes = new Point[defaultBackgroundStrokes.Length + 1];
            Array.Copy(defaultBackgroundStrokes, extendedBackgroundStrokes, defaultBackgroundStrokes.Length);
            extendedBackgroundStrokes[defaultBackgroundStrokes.Length] = new Point(5, 5); // example point

            // Extend foreground strokes with an additional point
            Point[] extendedForegroundStrokes = new Point[defaultForegroundStrokes.Length + 1];
            Array.Copy(defaultForegroundStrokes, extendedForegroundStrokes, defaultForegroundStrokes.Length);
            extendedForegroundStrokes[defaultForegroundStrokes.Length] = new Point(100, 100); // example point

            // Disable default stroke calculation and provide the extended points
            options.CalculateDefaultStrokes = false;
            options.Args = new AutoMaskingArgs
            {
                ObjectsPoints = new Point[][]
                {
                    extendedBackgroundStrokes,
                    extendedForegroundStrokes
                }
            };

            // ---------- Second auto‑masking pass (using modified strokes) ----------
            using (MaskingResult secondResult = new ImageMasking(image).Decompose(options))
            {
                // Save the updated foreground result
                using (RasterImage foreground = (RasterImage)secondResult[1].GetImage())
                {
                    foreground.Save(updatedOutputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }
    }
}