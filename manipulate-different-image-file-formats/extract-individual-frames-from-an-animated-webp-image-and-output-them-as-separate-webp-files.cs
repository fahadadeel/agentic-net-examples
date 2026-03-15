using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class ExtractWebPFrames
{
    static void Main()
    {
        // Path to the animated WebP file
        string inputPath = @"C:\temp\animated.webp";

        // Directory where individual frames will be saved
        string outputDir = @"C:\temp\frames";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the animated WebP image using the provided constructor
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Access all frames (pages) of the animated WebP
            Image[] frames = webPImage.Pages;

            // Iterate through each frame and save it as a separate WebP file
            for (int i = 0; i < frames.Length; i++)
            {
                // Build the output file name for the current frame
                string outputPath = Path.Combine(outputDir, $"frame_{i}.webp");

                // Save the frame using WebPOptions (default options)
                frames[i].Save(outputPath, new WebPOptions());
            }
        }
    }
}