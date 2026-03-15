using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input WebP file path
        string inputPath = "input.webp";
        // Output GIF file path
        string outputPath = "output.gif";

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Save the image as GIF using default options
            image.Save(outputPath, new GifOptions());
        }
    }
}