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
        string inputPath = "input.jpg";
        string outputPath = "output.png";
        string tempFile = Path.Combine(Path.GetTempPath(), "mask_temp.png");

        List<AssumedObjectData> assumedObjects = new List<AssumedObjectData>();
        assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Human, new Rectangle(100, 100, 150, 300)));

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
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
                    Source = new FileCreateSource(tempFile, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            MaskingResult results = new ImageMasking(image).Decompose(options);

            using (RasterImage foreground = (RasterImage)results[1].GetImage())
            {
                foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }

        if (File.Exists(tempFile))
        {
            File.Delete(tempFile);
        }
    }
}