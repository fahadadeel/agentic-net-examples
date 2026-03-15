using System;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG image, thumbnail JPEG image, and output path
        string inputPath = "input.jpg";
        string thumbnailPath = "thumb.jpg";
        string outputPath = "output_with_thumbnail.jpg";

        // Load the main JPEG image
        using (JpegImage mainImage = new JpegImage(inputPath))
        {
            // Load the thumbnail JPEG image (inherits RasterImage)
            using (JpegImage thumbImage = new JpegImage(thumbnailPath))
            {
                // Embed the thumbnail into the EXIF segment
                mainImage.ExifData.Thumbnail = thumbImage;
            }

            // Save the image with the embedded thumbnail
            mainImage.Save(outputPath);
        }
    }
}