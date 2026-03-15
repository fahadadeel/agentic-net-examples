using System;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Desired brightness adjustment (range: -255 to 255)
        int brightness = 50;

        // Load the image, adjust brightness, and save the result
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            raster.AdjustBrightness(brightness);
            raster.Save(outputPath);
        }
    }
}