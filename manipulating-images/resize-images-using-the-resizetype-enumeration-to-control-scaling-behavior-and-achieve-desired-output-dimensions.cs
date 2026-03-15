using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp; // Optional, for WebP support

class Program
{
    static void Main()
    {
        // Input image path
        string inputPath = "input.jpg";

        // Output directory (will be created if it doesn't exist)
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // ------------------------------------------------------------
        // Example 1: Downscale using NearestNeighbourResample
        // ------------------------------------------------------------
        using (Image image = Image.Load(inputPath)) // Load rule
        {
            // Resize to half the original dimensions
            image.Resize(image.Width / 2, image.Height / 2, ResizeType.NearestNeighbourResample);
            // Save the resized image (save rule)
            image.Save(Path.Combine(outputDir, "downsample_nearest.jpg"));
        }

        // ------------------------------------------------------------
        // Example 2: Upscale using BilinearResample
        // ------------------------------------------------------------
        using (Image image = Image.Load(inputPath))
        {
            // Resize to double the original dimensions
            image.Resize(image.Width * 2, image.Height * 2, ResizeType.BilinearResample);
            image.Save(Path.Combine(outputDir, "upsample_bilinear.jpg"));
        }

        // ------------------------------------------------------------
        // Example 3: Advanced resizing with ImageResizeSettings
        // ------------------------------------------------------------
        using (Image image = Image.Load(inputPath))
        {
            var resizeSettings = new ImageResizeSettings
            {
                // Choose a high‑quality resampling algorithm
                Mode = ResizeType.LanczosResample,
                // Small rectangular filter for better edge handling
                FilterType = ImageFilterType.SmallRectangular,
                // Color comparison method for quantization
                ColorCompareMethod = ColorCompareMethod.Euclidian,
                // Popularity quantization for palette reduction
                ColorQuantizationMethod = ColorQuantizationMethod.Popularity
            };

            // Resize to one third of the original size using the settings above
            image.Resize(image.Width / 3, image.Height / 3, resizeSettings);
            // Save as PNG to preserve quality
            image.Save(Path.Combine(outputDir, "downsample_advanced.png"), new PngOptions());
        }
    }
}