using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Configure PNG options: 24‑bit truecolor (8 bits per channel)
        PngOptions pngOptions = new PngOptions
        {
            BitDepth = 8,
            ColorType = PngColorType.Truecolor
        };

        // Create a 500x500 PNG image using the options
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing on the image
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a light gray background
            graphics.Clear(Color.LightGray);

            // Define the bounding rectangle for the ellipse (position and size)
            // Top‑left corner at (100, 80), width 300, height 200
            RectangleF ellipseRect = new RectangleF(100f, 80f, 300f, 200f);

            // Draw the ellipse outline with a black pen of thickness 3
            Pen pen = new Pen(Color.Black, 3);
            graphics.DrawEllipse(pen, ellipseRect);

            // Fill the ellipse with a semi‑transparent blue brush
            SolidBrush brush = new SolidBrush(Color.Blue);
            brush.Opacity = 128; // 50 % opacity
            graphics.FillEllipse(brush, ellipseRect);

            // Save the image (writes to the stream/source defined in pngOptions)
            image.Save();
        }
    }
}