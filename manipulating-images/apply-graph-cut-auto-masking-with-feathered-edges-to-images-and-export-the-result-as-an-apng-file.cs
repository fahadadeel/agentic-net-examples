using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.jpg";
        // Temporary file for masking export options
        string tempMaskPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the source image as RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure auto-masking options with graph cut and feathered edges
            var maskingOptions = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempMaskPath, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform masking
            using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
            {
                // Retrieve the foreground (masked object) image
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Create APNG image with the same dimensions as the foreground
                    var apngCreateOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngCreateOptions, foreground.Width, foreground.Height))
                    {
                        // Ensure only one frame exists
                        apng.RemoveAllFrames();
                        // Add the foreground as the sole frame
                        apng.AddFrame(foreground);
                        // Save the APNG file
                        apng.Save();
                    }
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