using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output BMP file path
        string outputPath = "output.bmp";

        // Define image dimensions
        int width = 100;
        int height = 100;

        // Prepare pixel data (ARGB format). Here we fill with a gradient.
        int[] pixels = new int[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Example: varying red and green components based on position
                byte a = 255;
                byte r = (byte)(x * 255 / (width - 1));
                byte g = (byte)(y * 255 / (height - 1));
                byte b = 0;
                pixels[y * width + x] = (a << 24) | (r << 16) | (g << 8) | b;
            }
        }

        // Create a file source for the BMP image
        Source source = new FileCreateSource(outputPath, false);

        // Set up BMP options with the source
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        // Create a raster canvas using the BMP options
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Write pixel data to the canvas
            canvas.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);

            // Save the bound image (no need to pass path or options)
            canvas.Save();
        }
    }
}