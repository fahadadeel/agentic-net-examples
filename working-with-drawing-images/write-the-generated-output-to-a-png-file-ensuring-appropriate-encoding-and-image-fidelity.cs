using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Configure PNG encoding options
        PngOptions pngOptions = new PngOptions
        {
            CompressionLevel = 9,                     // Maximum compression (0-9)
            Progressive = true,                       // Enable progressive loading
            ColorType = PngColorType.TruecolorWithAlpha, // Preserve alpha channel
            BitDepth = 8                               // 8 bits per channel
        };

        // Define image dimensions
        int width = 200;
        int height = 200;

        // Create a new PNG image canvas
        using (PngImage pngImage = new PngImage(width, height))
        {
            // Create a semi‑transparent linear gradient brush
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(pngImage.Width, pngImage.Height),
                Color.Blue,
                Color.Transparent))
            {
                // Obtain a graphics object for drawing
                Graphics graphics = new Graphics(pngImage);

                // Fill the entire image with the gradient
                graphics.FillRectangle(gradientBrush, pngImage.Bounds);
            }

            // Save the image with the specified PNG options
            pngImage.Save(outputPath, pngOptions);
        }
    }
}