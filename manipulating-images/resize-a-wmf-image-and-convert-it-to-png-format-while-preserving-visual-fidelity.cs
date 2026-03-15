using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path and output PNG file path
        string inputPath = args.Length > 0 ? args[0] : "input.wmf";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!image.IsCached)
                image.CacheData();

            // Define new dimensions (example: double the original size)
            int newWidth = image.Width * 2;
            int newHeight = image.Height * 2;

            // Resize with high‑quality Lanczos resampling to preserve visual fidelity
            image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // Configure PNG options with vector rasterization settings for WMF
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = new SizeF(newWidth, newHeight),
                    BackgroundColor = Color.White
                }
            };

            // Save the resized image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}