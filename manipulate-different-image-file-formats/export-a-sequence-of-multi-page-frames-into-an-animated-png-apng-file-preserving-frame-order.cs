using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input multi‑page image (e.g., TIFF, PDF, etc.)
        string inputPath = "input_multi_page.tif";
        // Output animated PNG file
        string outputPath = "output_animation.png";

        // Load the source image which may contain multiple pages/frames
        using (Image image = Image.Load(inputPath))
        {
            // Export all frames to an APNG while preserving their order
            image.Save(outputPath, new ApngOptions());
        }
    }
}