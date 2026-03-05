using System;
using System.IO;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputDir = "output_svgs";
        Directory.CreateDirectory(outputDir);
        using (var pres = new Aspose.Slides.Presentation(inputPath))
        {
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                var slide = pres.Slides[i];
                var svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (var fileStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }
            pres.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}