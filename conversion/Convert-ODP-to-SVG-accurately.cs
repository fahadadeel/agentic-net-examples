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
            var inputPath = "input.odp";
            var outputFolder = "output_svgs";
            Directory.CreateDirectory(outputFolder);
            using (var presentation = new Presentation(inputPath))
            {
                for (var i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    var svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                    using (var stream = File.Create(svgPath))
                    {
                        slide.WriteAsSvg(stream);
                    }
                }
                var savedPath = "saved_output.pptx";
                presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}