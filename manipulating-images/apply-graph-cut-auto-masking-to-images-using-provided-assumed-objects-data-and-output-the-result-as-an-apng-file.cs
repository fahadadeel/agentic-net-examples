using System;
using System.IO;
using System.Collections.Generic;
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
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";
        string outputPath = args.Length > 1 ? args[1] : "output.apng";

        string tempPng = Path.Combine(Path.GetTempPath(), "mask_temp.png");

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            List<AssumedObjectData> assumedObjects = new List<AssumedObjectData>();
            assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Human, new Rectangle(100, 100, 150, 300)));

            AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
            {
                AssumedObjects = assumedObjects,
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempPng, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            using (MaskingResult maskingResult = new ImageMasking(image).Decompose(options))
            using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
            {
                foreground.Save(outputPath, new ApngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 200,
                    NumPlays = 0
                });
            }
        }

        if (File.Exists(tempPng))
        {
            File.Delete(tempPng);
        }
    }
}