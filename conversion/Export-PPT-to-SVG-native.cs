using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputPath = "input.pptx";
                var outputPresentationPath = "output.pptx";

                using (var presentation = new Presentation(inputPath))
                {
                    for (var i = 0; i < presentation.Slides.Count; i++)
                    {
                        var slide = presentation.Slides[i];
                        var svgPath = $"slide_{i + 1}.svg";

                        using (var fileStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}