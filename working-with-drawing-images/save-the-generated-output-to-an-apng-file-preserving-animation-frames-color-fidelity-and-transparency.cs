using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source animated image (e.g., GIF, WebP, multi‑page TIFF)
        string sourcePath = "input_animation.webp";

        // Desired output APNG file path
        string outputPath = "output_animation.apng";

        // Load the source image which already contains animation frames
        using (Image image = Image.Load(sourcePath))
        {
            // Save the loaded image as an APNG, preserving all frames,
            // color fidelity and transparency.
            // NumPlays = 0 means the animation will loop infinitely.
            image.Save(outputPath, new ApngOptions
            {
                NumPlays = 0
            });
        }
    }
}