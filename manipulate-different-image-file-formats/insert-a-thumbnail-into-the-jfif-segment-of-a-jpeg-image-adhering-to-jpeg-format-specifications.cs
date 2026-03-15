using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Jpeg.Jfif;
using Aspose.Imaging.ImageOptions;

class InsertJfifThumbnail
{
    static void Main()
    {
        // Load the source JPEG image
        using (JpegImage jpeg = (JpegImage)Image.Load("input.jpg"))
        {
            // Create a thumbnail (e.g., 160x120) from the source image
            using (RasterImage thumb = jpeg.Clone())
            {
                thumb.Resize(new Size(160, 120), ResizeType.NearestNeighbour);

                // Ensure the JFIF segment exists
                if (jpeg.Jfif == null)
                {
                    jpeg.Jfif = new JFIFData();
                }

                // Assign the thumbnail to the JFIF segment
                // Clone the thumbnail so the JFIF segment owns its own instance
                jpeg.Jfif.Thumbnail = thumb.Clone() as RasterImage;
            }

            // Save the JPEG with the new JFIF thumbnail
            jpeg.Save("output.jpg");
        }
    }
}