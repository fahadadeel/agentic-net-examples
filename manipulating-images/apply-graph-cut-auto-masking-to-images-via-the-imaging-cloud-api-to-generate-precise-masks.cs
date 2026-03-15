using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";
        string tempMaskPath = Path.Combine(Path.GetTempPath(), "tempMask.png");

        // Load the source image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure auto masking options with GraphCut
            AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempMaskPath)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform the masking operation
            using (MaskingResult maskingResult = new ImageMasking(image).Decompose(options))
            {
                // Retrieve the foreground (masked) image
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save the result with transparent background
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }

        // Clean up temporary mask file
        if (File.Exists(tempMaskPath))
        {
            File.Delete(tempMaskPath);
        }
    }
}