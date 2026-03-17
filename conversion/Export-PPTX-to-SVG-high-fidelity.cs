using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputPath = "input.pptx";
                var presentation = new Presentation(inputPath);

                for (var i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    var outputPath = $"slide_{i + 1}.svg";

                    using (var fileStream = File.Create(outputPath))
                    {
                        slide.WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation (no modifications) before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}