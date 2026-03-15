using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ImageFormatConverter
{
    static void Main()
    {
        // Path to the source image (any supported format, e.g., PNG)
        string sourcePath = @"C:\Images\sample.png";

        // Desired output path with the new format extension (e.g., JPEG)
        string destinationPath = @"C:\Images\sample_converted.jpg";

        // Load the image using Aspose.Imaging's factory method
        using (Image image = Image.Load(sourcePath))
        {
            // Create JPEG save options (you can customize quality, compression, etc.)
            JpegOptions jpegOptions = new JpegOptions
            {
                // Example: set the compression quality to 90 (range 0-100)
                Quality = 90
            };

            // Save the loaded image to the new format using the specified options
            image.Save(destinationPath, jpegOptions);
        }

        Console.WriteLine("Image conversion completed successfully.");
    }
}