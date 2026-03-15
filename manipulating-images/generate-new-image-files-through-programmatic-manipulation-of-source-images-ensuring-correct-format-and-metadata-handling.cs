using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Paths for source and output images
        string inputPath = "input.jpg";
        string pngPath = "output.png";
        string tiffPath = "output.tiff";

        // Load the JPEG image, resize it, add a text watermark, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // High‑quality resize using Lanczos resampling
            image.Resize(800, 600, ResizeType.LanczosResample);

            // Draw watermark text onto the image
            Graphics graphics = new Graphics(image);
            Font font = new Font("Arial", 24);
            SolidBrush brush = new SolidBrush(Color.Yellow);
            Point position = new Point(image.Width - 200, image.Height - 40);
            graphics.DrawString("Sample Watermark", font, brush, position);

            // Save the processed image as PNG
            using (PngOptions pngOptions = new PngOptions())
            {
                image.Save(pngPath, pngOptions);
            }
        }

        // Load the PNG image and convert it to TIFF with LZW compression
        using (Image pngImage = Image.Load(pngPath))
        {
            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzw))
            {
                pngImage.Save(tiffPath, tiffOptions);
            }
        }
    }
}