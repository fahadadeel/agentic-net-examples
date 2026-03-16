using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure PNG options and associate the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 400x400 raster image
            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                // Initialize the Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear the canvas with a white background
                graphics.Clear(Color.White);

                // Define pens with specific colors and thicknesses
                Pen redPen   = new Pen(Color.Red,   3); // 3-pixel wide red line
                Pen bluePen  = new Pen(Color.Blue,  5); // 5-pixel wide blue line
                Pen greenPen = new Pen(Color.Green, 2); // 2-pixel wide green line

                // Draw multiple line primitives
                // Line 1: horizontal red line
                graphics.DrawLine(redPen, 50, 50, 350, 50);

                // Line 2: diagonal blue line
                graphics.DrawLine(bluePen, 50, 100, 350, 200);

                // Line 3: diagonal green line
                graphics.DrawLine(greenPen, 50, 150, 350, 350);

                // Persist changes to the image
                image.Save();
            }
        }
    }
}