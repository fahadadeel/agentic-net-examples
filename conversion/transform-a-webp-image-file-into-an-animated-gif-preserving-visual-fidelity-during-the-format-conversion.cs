using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class WebPToGifConverter
{
    static void Main()
    {
        // Path to the source WebP file (can be animated)
        string sourceWebP = @"C:\Images\input.webp";

        // Desired output path for the animated GIF
        string destinationGif = @"C:\Images\output.gif";

        // Load the WebP image (single or multi‑frame) using Aspose.Imaging's load rule
        using (Image webPImage = Image.Load(sourceWebP))
        {
            // Save the loaded image as an animated GIF.
            // GifOptions ensures the output format is GIF and preserves all frames.
            webPImage.Save(destinationGif, new GifOptions());
        }
    }
}