using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Path to the JPEG image
        string imagePath = "sample.jpg";

        // Load the JPEG image using Aspose.Imaging
        using (JpegImage jpegImage = (JpegImage)Image.Load(imagePath))
        {
            // Retrieve the EXIF data container
            JpegExifData jpegExif = jpegImage.ExifData as JpegExifData;

            if (jpegExif != null)
            {
                // Output selected EXIF tags
                Console.WriteLine($"Make: {jpegExif.Make}");
                Console.WriteLine($"Model: {jpegExif.Model}");
                Console.WriteLine($"Orientation: {jpegExif.Orientation}");
                Console.WriteLine($"Software: {jpegExif.Software}");
                Console.WriteLine($"Date/Time: {jpegExif.DateTime}");
                Console.WriteLine($"Exposure Time: {jpegExif.ExposureTime}");
                Console.WriteLine($"FNumber: {jpegExif.FNumber}");
                Console.WriteLine($"ISO Speed: {jpegExif.ISOSpeed}");
                // Add additional tags as required
            }
            else
            {
                Console.WriteLine("No EXIF data found in the image.");
            }
        }
    }
}