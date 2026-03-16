using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.png";

        FileCreateSource source = new FileCreateSource(outputPath, false);

        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = source;

        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);
            image.Save();
        }
    }
}