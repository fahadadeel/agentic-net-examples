using System;
using System.IO;

namespace AsposeSlidesSvgExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the ODP presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.odp");

            // Export each slide to a separate SVG file
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                string svgPath = $"slide_{i + 1}.svg";

                using (FileStream fileStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation (required before exit)
            presentation.Save("output.odp", Aspose.Slides.Export.SaveFormat.Odp);
        }
    }
}