using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input animated image path and output APNG path
        string inputPath = "input_animation.webp";
        string outputPath = "output_resized.apng";

        // Desired dimensions for each frame
        int targetWidth = 200;
        int targetHeight = 200;

        // Load the source image (may contain multiple frames)
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Configure APNG creation options
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG canvas with the target size
            using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, targetWidth, targetHeight))
            {
                apngImage.RemoveAllFrames();

                // If the source image is multipage (animated), process each frame
                if (sourceImage is IMultipageImage multipage)
                {
                    foreach (var page in multipage.Pages)
                    {
                        using (RasterImage frame = (RasterImage)page)
                        {
                            if (!frame.IsCached) frame.CacheData();
                            frame.Resize(targetWidth, targetHeight, ResizeType.LanczosResample);
                            apngImage.AddFrame(frame);
                        }
                    }
                }
                else
                {
                    // Single-frame image handling
                    using (RasterImage frame = (RasterImage)sourceImage)
                    {
                        if (!frame.IsCached) frame.CacheData();
                        frame.Resize(targetWidth, targetHeight, ResizeType.LanczosResample);
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the resulting APNG
                apngImage.Save();
            }
        }
    }
}