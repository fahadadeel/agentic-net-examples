using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            image.Save(outputPath, options);
        }
    }
}