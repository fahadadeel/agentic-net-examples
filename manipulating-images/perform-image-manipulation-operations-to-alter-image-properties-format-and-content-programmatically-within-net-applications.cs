using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string tiffPath = "input.tif";
        string jpegPath = "output.jpg";
        string webpPath = "output.webp";
        string mergedPath = "merged.jpg";

        // Load TIFF image, adjust, resize, rotate and save as JPEG
        using (TiffImage tiff = (TiffImage)Image.Load(tiffPath))
        {
            if (!tiff.IsCached) tiff.CacheData();

            // Adjust brightness and contrast
            tiff.AdjustBrightness(30);          // Increase brightness
            tiff.AdjustContrast(0.2f);          // Increase contrast

            // Resize to 800x600
            tiff.Resize(800, 600);

            // Rotate 45 degrees, resize canvas proportionally, fill empty area with white
            tiff.Rotate(45f, true, Color.White);

            // Save as JPEG with quality 90
            JpegOptions jpegOpts = new JpegOptions { Quality = 90 };
            tiff.Save(jpegPath, jpegOpts);
        }

        // Load the saved JPEG and convert to WebP
        using (JpegImage jpeg = (JpegImage)Image.Load(jpegPath))
        {
            if (!jpeg.IsCached) jpeg.CacheData();

            WebPOptions webpOpts = new WebPOptions();
            jpeg.Save(webpPath, webpOpts);
        }

        // Load both images again for merging side by side
        using (TiffImage tiff = (TiffImage)Image.Load(tiffPath))
        using (JpegImage jpeg = (JpegImage)Image.Load(jpegPath))
        {
            if (!tiff.IsCached) tiff.CacheData();
            if (!jpeg.IsCached) jpeg.CacheData();

            int canvasWidth = tiff.Width + jpeg.Width;
            int canvasHeight = Math.Max(tiff.Height, jpeg.Height);

            // Create output canvas bound to a file
            Source canvasSource = new FileCreateSource(mergedPath, false);
            JpegOptions canvasOpts = new JpegOptions { Source = canvasSource, Quality = 80 };
            using (JpegImage canvas = (JpegImage)Image.Create(canvasOpts, canvasWidth, canvasHeight))
            {
                // Draw first image at (0,0)
                Rectangle rect1 = new Rectangle(0, 0, tiff.Width, tiff.Height);
                canvas.SaveArgb32Pixels(rect1, tiff.LoadArgb32Pixels(tiff.Bounds));

                // Draw second image next to the first
                Rectangle rect2 = new Rectangle(tiff.Width, 0, jpeg.Width, jpeg.Height);
                canvas.SaveArgb32Pixels(rect2, jpeg.LoadArgb32Pixels(jpeg.Bounds));

                // Persist the canvas to the file
                canvas.Save();
            }
        }
    }
}