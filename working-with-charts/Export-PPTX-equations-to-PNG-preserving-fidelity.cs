using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputFolder = "output_images";
            Directory.CreateDirectory(outputFolder);
            using (var pres = new Presentation(inputPath))
            {
                for (var i = 0; i < pres.Slides.Count; i++)
                {
                    var slide = pres.Slides[i];
                    var image = slide.GetImage(2f, 2f);
                    var imagePath = Path.Combine(outputFolder, $"slide_{i + 1}.png");
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                    image.Dispose();
                }
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}