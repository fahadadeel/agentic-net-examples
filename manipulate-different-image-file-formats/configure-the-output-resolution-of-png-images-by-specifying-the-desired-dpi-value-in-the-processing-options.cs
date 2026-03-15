using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        double dpiX = 300.0;
        double dpiY = 300.0;

        using (Image image = Image.Load(inputPath))
        {
            PngOptions pngOptions = new PngOptions
            {
                ResolutionSettings = new ResolutionSetting(dpiX, dpiY)
            };

            image.Save(outputPath, pngOptions);
        }
    }
}