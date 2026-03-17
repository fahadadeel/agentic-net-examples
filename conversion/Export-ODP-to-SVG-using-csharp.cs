using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.odp";
            var outputDir = "output_svg";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    var svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                    using (var fileStream = File.Create(svgPath))
                    {
                        slide.WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation in a supported format before exiting
                presentation.Save("converted.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}