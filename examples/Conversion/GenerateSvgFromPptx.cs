using System;
using System.IO;
using Aspose.Slides;

namespace SvgExportApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "input.pptx";
            var outputPresentationPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (var i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    var svgPath = $"slide_{i}.svg";
                    using (var fileStream = File.Create(svgPath))
                    {
                        slide.WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation (even if unchanged) before exiting
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}