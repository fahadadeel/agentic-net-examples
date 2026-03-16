using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Configure PNG options with a memory buffer limit
        ImageOptionsBase options = new PngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            BufferSizeHint = 30 // limit internal buffers to 30 MB
        };

        const int imageSize = 2000;

        // Create the image using the configured options
        using (Image image = Image.Create(options, imageSize, imageSize))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.BeginUpdate(); // batch drawing operations to reduce memory churn

            // Clear background
            graphics.Clear(Color.LightGray);

            // Draw a dense grid of lines
            int step = 10;
            for (int x = 0; x < imageSize; x += step)
            {
                graphics.DrawLine(new Pen(Color.Blue, 1), x, 0, x, imageSize);
            }
            for (int y = 0; y < imageSize; y += step)
            {
                graphics.DrawLine(new Pen(Color.Red, 1), 0, y, imageSize, y);
            }

            // Draw additional shapes
            graphics.DrawRectangle(new Pen(Color.Green, 2), new Rectangle(100, 100, 400, 300));
            graphics.FillEllipse(new SolidBrush(Color.FromArgb(128, Color.Yellow)), new Rectangle(600, 600, 300, 200));

            // Draw text
            Font font = new Font("Arial", 48);
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            {
                graphics.DrawString("Memory Efficient", font, textBrush, new PointF(200, 1500));
            }

            graphics.EndUpdate(); // apply all batched operations

            // Save the image (bound to the file source)
            image.Save();
        }
    }
}