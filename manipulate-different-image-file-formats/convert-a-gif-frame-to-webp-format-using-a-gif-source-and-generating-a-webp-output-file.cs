using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class GifToWebpConverter
{
    static void Main()
    {
        // Define input GIF file and output WebP file paths
        string inputGifPath = @"C:\temp\input.gif";
        string outputWebpPath = @"C:\temp\output.webp";

        // Load the GIF image (can be animated or single‑frame)
        using (Image gifImage = Image.Load(inputGifPath))
        {
            // Configure WebP saving options (adjust as needed)
            WebPOptions webpOptions = new WebPOptions
            {
                // Example: use lossless compression with maximum quality
                Lossless = true,
                Quality = 100f
            };

            // Save the loaded GIF (or its active frame) as a WebP image
            gifImage.Save(outputWebpPath, webpOptions);
        }
    }
}