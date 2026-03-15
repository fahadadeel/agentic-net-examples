using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Path to the source image file
        string sourcePath = @"C:\temp\sample.bmp";

        // Load the image from disk
        using (Image image = Image.Load(sourcePath))
        {
            // Resize the image to the desired dimensions (e.g., 200x200)
            image.Resize(200, 200);

            // Apply a simple filter – binarization using Otsu's method.
            // This demonstrates a transformation; replace with other filters as needed.
            if (image is BmpImage bmpImage)
            {
                bmpImage.BinarizeOtsu();
            }

            // Set up PNG save options to convert the image format to PNG
            PngOptions pngOptions = new PngOptions();

            // Save the processed image into a memory stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, pngOptions);

                // The memory stream now contains the PNG data.
                // Example usage: output the size of the resulting image.
                Console.WriteLine($"Processed image size (bytes): {memoryStream.Length}");
            }
        }
    }
}