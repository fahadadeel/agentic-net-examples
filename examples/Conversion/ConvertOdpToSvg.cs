using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Path to the source ODP file
        string inputPath = "input.odp";

        // Load the ODP presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Convert each slide to an individual SVG file
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                string svgFileName = $"slide_{index + 1}.svg";

                using (Stream svgStream = File.Create(svgFileName))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Save the presentation before exiting (no modifications made)
            presentation.Save("output.odp", Aspose.Slides.Export.SaveFormat.Odp);
        }
    }
}