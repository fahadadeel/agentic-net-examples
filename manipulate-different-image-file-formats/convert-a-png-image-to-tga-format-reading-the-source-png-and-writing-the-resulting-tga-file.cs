using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input PNG file path and output TGA file path.
        string inputPath = "input.png";
        string outputPath = "output.tga";

        // Load the PNG image as a raster image.
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Save the raster image as TGA using default TgaOptions.
            image.Save(outputPath, new TgaOptions());
        }
    }
}