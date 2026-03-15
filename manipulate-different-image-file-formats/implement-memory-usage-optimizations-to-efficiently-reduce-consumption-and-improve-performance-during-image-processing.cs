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
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputImagePath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the source image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Preserve original dimensions for later use
            Size originalSize = sourceImage.Size;

            // Reduce image size to lower memory consumption during segmentation
            sourceImage.ResizeHeightProportionally(600, ResizeType.HighQualityResample);

            // Configure export options to use an in‑memory stream (no temp files)
            PngOptions exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Set up masking options (auto‑masking with GraphCut, transparent background)
            Aspose.Imaging.Masking.Options.MaskingOptions maskingOptions = new Aspose.Imaging.Masking.Options.MaskingOptions
            {
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                Decompose = false,
                Args = new Aspose.Imaging.Masking.Options.AutoMaskingArgs(),
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Perform masking on the reduced‑size image
            Aspose.Imaging.Masking.ImageMasking masking = new Aspose.Imaging.Masking.ImageMasking(sourceImage);
            using (Aspose.Imaging.Masking.Result.MaskingResult maskingResult = masking.Decompose(maskingOptions))
            {
                // Obtain the foreground mask (index 1)
                using (RasterImage foregroundMask = (RasterImage)maskingResult[1].GetMask())
                {
                    // Restore mask to original image dimensions
                    foregroundMask.Resize(originalSize.Width, originalSize.Height, ResizeType.NearestNeighbourResample);

                    // Reload the original full‑size image for final composition
                    using (RasterImage fullSizeImage = (RasterImage)Image.Load(inputPath))
                    {
                        // Apply the mask to the original image
                        Aspose.Imaging.Masking.ImageMasking.ApplyMask(fullSizeImage, foregroundMask, maskingOptions);

                        // Save the result using the same in‑memory export options
                        fullSizeImage.Save(outputPath, exportOptions);
                    }
                }
            }
        }
    }
}