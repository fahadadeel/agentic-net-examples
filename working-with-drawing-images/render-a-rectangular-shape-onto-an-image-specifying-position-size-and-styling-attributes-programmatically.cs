using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 400x300 image
            using (Image image = Image.Create(pngOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background with white color
                graphics.Clear(Color.White);

                // Define rectangle position and size
                int rectX = 50;
                int rectY = 60;
                int rectWidth = 200;
                int rectHeight = 150;

                // Create a pen with blue color and 3-pixel width
                Pen pen = new Pen(Color.Blue, 3);

                // Draw the rectangle
                graphics.DrawRectangle(pen, rectX, rectY, rectWidth, rectHeight);

                // Save changes to the bound stream
                image.Save();
            }
        }
    }
}