using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class BackgroundRemoval
{
    static void Main()
    {
        // Input and output file paths
        string inputFile = @"C:\Images\input.jpg";
        string outputFile = @"C:\Images\output.png";

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputFile))
        {
            // Prepare export options for the resulting image (PNG with alpha channel)
            var exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure masking options:
            // - Use GraphCut segmentation (good for complex backgrounds)
            // - Do not decompose into separate objects; we need a single foreground mask
            // - Set background replacement color to Transparent
            var maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                Args = new AutoMaskingArgs(), // default arguments
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Create ImageMasking instance for the source image
            var masking = new ImageMasking(sourceImage);

            // Perform masking to obtain the foreground mask
            using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
            {
                // The foreground is usually the first non‑background layer (index 1)
                using (RasterImage foregroundMask = maskingResult[1].GetMask())
                {
                    // Ensure mask size matches the original image size
                    foregroundMask.Resize(sourceImage.Width, sourceImage.Height, ResizeType.NearestNeighbourResample);

                    // Apply the mask to the original image – background becomes transparent
                    ImageMasking.ApplyMask(sourceImage, foregroundMask, maskingOptions);
                }
            }

            // Save the processed image (foreground with transparent background)
            sourceImage.Save(outputFile, exportOptions);
        }
    }
}