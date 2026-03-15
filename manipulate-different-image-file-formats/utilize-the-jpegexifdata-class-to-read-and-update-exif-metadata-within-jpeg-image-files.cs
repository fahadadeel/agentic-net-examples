using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input and output JPEG file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Access EXIF data as JpegExifData
            var jpegExif = image.ExifData as Aspose.Imaging.Exif.JpegExifData;
            if (jpegExif != null)
            {
                // Update some EXIF fields
                jpegExif.Make = "MyCameraManufacturer";
                jpegExif.Model = "ModelX1000";
                jpegExif.Artist = "John Doe";
                jpegExif.Copyright = "© 2024 MyCompany";
            }

            // Save the modified image
            image.Save(outputPath);
        }
    }
}