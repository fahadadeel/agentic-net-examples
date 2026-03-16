using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "output.bmp";

        // Image dimensions
        int width = 400;
        int height = 200;

        // Unicode text to render
        string text = "こんにちは世界 🌍";

        // Create a BMP image with 24 bits per pixel
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24
        };

        // Create the image using the provided lifecycle method
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Obtain a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Enable antialiasing for smoother lines and text
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Set text rendering hint to antialias (high‑quality text)
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            // Clear the background to white
            graphics.Clear(Color.White);

            // Define the font (Arial Unicode MS supports many Unicode ranges)
            Font font = new Font("Arial Unicode MS", 32, FontStyle.Regular);

            // Define a solid brush for the text color
            SolidBrush brush = new SolidBrush(Color.Black);

            // Draw the Unicode string at the desired location
            graphics.DrawString(text, font, brush, 10, 50);

            // Save the image using the provided lifecycle method
            image.Save(outputPath);
        }
    }
}