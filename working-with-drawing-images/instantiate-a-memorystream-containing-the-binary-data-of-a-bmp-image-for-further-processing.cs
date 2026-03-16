using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source BMP file
        string bmpPath = "sample.bmp";

        // Load the BMP image using Aspose.Imaging
        using (Image image = Image.Load(bmpPath))
        {
            // Create a memory stream to hold the BMP binary data
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the loaded image into the memory stream in BMP format
                BmpOptions bmpOptions = new BmpOptions();
                image.Save(memoryStream, bmpOptions);

                // Reset the stream position for subsequent reading
                memoryStream.Position = 0;

                // Example of further processing: load the BMP image from the memory stream
                using (BmpImage bmpFromStream = new BmpImage(memoryStream))
                {
                    Console.WriteLine($"Width: {bmpFromStream.Width}, Height: {bmpFromStream.Height}");
                }
            }
        }
    }
}