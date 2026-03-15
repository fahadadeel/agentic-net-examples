using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Desired width while preserving aspect ratio
        int targetWidth = 800;

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Resize proportionally using high-quality Lanczos resampling
            image.ResizeWidthProportionally(targetWidth, ResizeType.LanczosResample);

            // Save the resized image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}