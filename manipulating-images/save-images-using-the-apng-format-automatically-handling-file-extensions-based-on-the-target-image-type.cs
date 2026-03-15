using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source image (can be any supported format)
        string sourcePath = "input.webp";

        // Load the image using Aspose.Imaging's lifecycle rule
        using (Image image = Image.Load(sourcePath))
        {
            // Generate the output file name by replacing the original extension with .png
            // APNG files are stored with a .png extension
            string outputPath = Path.ChangeExtension(sourcePath, ".png");

            // Save the loaded image as an APNG using default options
            // The ApngOptions class inherits from PngOptions and configures the file as an animated PNG
            image.Save(outputPath, new ApngOptions());
        }
    }
}