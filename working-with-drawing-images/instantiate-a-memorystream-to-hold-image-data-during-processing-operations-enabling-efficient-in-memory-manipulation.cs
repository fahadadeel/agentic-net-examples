using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source image file
        string inputPath = "input.jpg";
        // Optional path to save the processed image from the memory stream
        string outputPath = "output.png";

        // Create a MemoryStream to hold image data in memory
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Load the image from disk
            using (Image image = Image.Load(inputPath))
            {
                // Perform a sample operation (rotate 90 degrees)
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the processed image into the memory stream using PNG format
                PngOptions pngOptions = new PngOptions();
                image.Save(memoryStream, pngOptions);
            }

            // Reset stream position before reading
            memoryStream.Position = 0;

            // Write the memory stream contents to a file (optional)
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                memoryStream.CopyTo(fileStream);
            }
        }
    }
}