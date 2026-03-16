using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input PNG file; can be passed as a command‑line argument
        string inputPath = args.Length > 0 ? args[0] : "input.png";

        // Open the PNG file as a stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        {
            // Load the PNG image from the stream
            using (PngImage pngImage = new PngImage(inputStream))
            {
                // Create a Graphics object for drawing on the loaded image
                Graphics graphics = new Graphics(pngImage);

                // Optional preparation: clear the canvas with a solid color
                graphics.Clear(Color.White);

                // The 'graphics' instance is now ready for further drawing operations
                // Example: graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 10), new Point(100, 100));

                // Save the image if desired
                // pngImage.Save("output.png");
            }
        }
    }
}