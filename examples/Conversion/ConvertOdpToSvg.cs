using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source ODP file
        string inputPath = "input.odp";

        // Load the ODP presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Convert each slide to an SVG file
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                string svgPath = $"slide_{i + 1}.svg";

                using (FileStream svgStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Save the presentation before exiting (optional)
            presentation.Save("output.odp", Aspose.Slides.Export.SaveFormat.Odp);
        }
    }
}