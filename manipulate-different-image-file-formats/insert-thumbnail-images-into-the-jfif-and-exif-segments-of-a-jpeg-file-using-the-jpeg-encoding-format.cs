using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Jpeg.JFIF;
using Aspose.Imaging.Exif;

// Load the original JPEG image
using (Image image = Image.Load("input.jpg"))
{
    // Cast to JpegImage to access JPEG‑specific properties
    JpegImage jpeg = (JpegImage)image;

    // Create a thumbnail by resizing the original image (e.g., 160x120)
    // The Resize method returns a new RasterImage instance
    using (RasterImage thumbnail = (RasterImage)jpeg.Clone())
    {
        // Resize the clone to thumbnail dimensions
        thumbnail.Resize(160, 120);

        // Assign the thumbnail to the EXIF segment
        // ExifData may be null if the source image has no EXIF block, so create it if necessary
        if (jpeg.ExifData == null)
        {
            jpeg.ExifData = new JpegExifData();
        }
        jpeg.ExifData.Thumbnail = thumbnail;

        // Assign the same thumbnail to the JFIF segment
        // Jfif may be null; create a new JFIFData instance if needed
        if (jpeg.Jfif == null)
        {
            jpeg.Jfif = new JFIFData();
        }
        jpeg.Jfif.Thumbnail = thumbnail;

        // Save the modified JPEG with the new thumbnail data
        jpeg.Save("output.jpg");
    }
}