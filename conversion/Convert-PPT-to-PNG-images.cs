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
            string inputPath = "input.pptx";
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            int slideCount = pres.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                Aspose.Slides.IImage image = slide.GetImage();
                string outputPath = $"slide_{i}.png";
                image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                image.Dispose();
            }
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}