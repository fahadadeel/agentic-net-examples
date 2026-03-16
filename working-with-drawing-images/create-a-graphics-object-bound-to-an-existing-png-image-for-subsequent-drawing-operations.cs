using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the existing PNG and the output file
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the existing PNG image
        using (PngImage png = new PngImage(inputPath))
        {
            // Create a Graphics object bound to the loaded image
            Graphics graphics = new Graphics(png);

            // Example operation: clear the image surface with white color
            graphics.Clear(Color.White);

            // Save the modified image
            png.Save(outputPath);
        }
    }
}