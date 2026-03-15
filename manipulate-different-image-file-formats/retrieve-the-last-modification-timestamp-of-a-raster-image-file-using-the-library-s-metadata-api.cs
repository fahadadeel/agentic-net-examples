using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;      // For PNG images
using Aspose.Imaging.FileFormats.Jpeg;     // For JPEG images
using Aspose.Imaging.FileFormats.Apng;     // For APNG images
using Aspose.Imaging.FileFormats.Tga;      // For TGA images

class Program
{
    static void Main()
    {
        // Path to the raster image file (can be PNG, JPEG, APNG, TGA, etc.)
        string imagePath = "sample.png";

        // Load the image using Aspose.Imaging's Image.Load method.
        // The returned object is cast to RasterImage to access common raster functionality.
        using (RasterImage image = (RasterImage)Image.Load(imagePath))
        {
            // Retrieve the last modification timestamp.
            // Pass 'true' to use the file system's timestamp as a default if the image metadata does not contain it.
            DateTime lastModified = image.GetModifyDate(useDefault: true);

            // Output the result.
            Console.WriteLine($"Last modification date of '{imagePath}': {lastModified}");
        }
    }
}