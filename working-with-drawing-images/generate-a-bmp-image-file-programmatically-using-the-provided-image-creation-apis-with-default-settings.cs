using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = "output.bmp";

        // Create a source bound to the output file
        Source source = new FileCreateSource(outputPath, false);

        // Set up BMP creation options with the bound source
        BmpOptions options = new BmpOptions
        {
            Source = source
        };

        // Define canvas size
        int width = 200;
        int height = 200;

        // Create the BMP image canvas
        using (Image canvas = Image.Create(options, width, height))
        {
            // Fill the canvas with a solid red color
            Graphics graphics = new Graphics(canvas);
            SolidBrush brush = new SolidBrush(Color.Red);
            graphics.FillRectangle(brush, canvas.Bounds);

            // Save the bound image (no path needed)
            canvas.Save();
        }
    }
}