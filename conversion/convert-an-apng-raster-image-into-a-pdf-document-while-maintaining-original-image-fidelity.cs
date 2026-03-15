using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output.pdf";

        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, new PdfOptions());
        }
    }
}