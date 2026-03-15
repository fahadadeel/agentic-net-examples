using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input arguments: inputPath outputPath seedX seedY featheringRadius
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        int seedX = args.Length > 2 && int.TryParse(args[2], out int sx) ? sx : 100;
        int seedY = args.Length > 3 && int.TryParse(args[3], out int sy) ? sy : 100;
        int featheringRadius = args.Length > 4 && int.TryParse(args[4], out int fr) ? fr : 3;

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Temporary file for ExportOptions source
            string tempPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");

            var options = new GraphCutMaskingOptions
            {
                FeatheringRadius = featheringRadius,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempPath)
                },
                BackgroundReplacementColor = Color.Transparent,
                Args = new AutoMaskingArgs
                {
                    ObjectsPoints = new Point[][]
                    {
                        new Point[] { new Point(seedX, seedY) }
                    }
                }
            };

            using (MaskingResult maskingResult = new ImageMasking(image).Decompose(options))
            {
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            // Clean up temporary file
            if (File.Exists(tempPath))
                File.Delete(tempPath);
        }
    }
}