using System;
using Aspose.Imaging.FileFormats.Jpeg;

class ThumbnailGenerator
{
    // Generates a JPEG thumbnail while preserving the aspect ratio.
    // Parameters:
    //   sourcePath - full path to the source JPEG image.
    //   thumbnailPath - full path where the thumbnail will be saved.
    //   maxDimension - maximum width or height of the thumbnail (in pixels).
    public static void CreateThumbnail(string sourcePath, string thumbnailPath, int maxDimension)
    {
        // Load the source JPEG image using the provided constructor rule.
        using (JpegImage jpegImage = new JpegImage(sourcePath))
        {
            // Determine the scaling factor to fit within the max dimension while preserving aspect ratio.
            double widthRatio = (double)maxDimension / jpegImage.Width;
            double heightRatio = (double)maxDimension / jpegImage.Height;
            double scale = Math.Min(widthRatio, heightRatio);

            // If the image is already smaller than the requested size, keep original dimensions.
            if (scale < 1.0)
            {
                int newWidth = (int)(jpegImage.Width * scale);
                int newHeight = (int)(jpegImage.Height * scale);

                // Resize the image using the Resize method (preserves aspect ratio because we calculated dimensions).
                jpegImage.Resize(newWidth, newHeight);
            }

            // Save the thumbnail as a JPEG using the provided Save method rule.
            jpegImage.Save(thumbnailPath);
        }
    }

    // Example usage.
    static void Main()
    {
        string source = @"C:\Images\photo.jpg";
        string thumb = @"C:\Images\photo_thumb.jpg";
        int maxSize = 150; // Max width or height for the thumbnail.

        CreateThumbnail(source, thumb, maxSize);
    }
}