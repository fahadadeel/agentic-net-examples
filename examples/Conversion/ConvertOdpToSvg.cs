using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Path to the source ODP file
        var inputPath = "input.odp";

        // Folder where SVG files will be saved
        var outputFolder = "output_svg";
        Directory.CreateDirectory(outputFolder);

        // Load the ODP presentation
        using (var pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Convert each slide to an SVG file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                var svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                using (var fs = File.Create(svgPath))
                {
                    pres.Slides[i].WriteAsSvg(fs);
                }
            }

            // Save the presentation before exiting
            pres.Save("saved_output.odp", Aspose.Slides.Export.SaveFormat.Odp);
        }
    }
}