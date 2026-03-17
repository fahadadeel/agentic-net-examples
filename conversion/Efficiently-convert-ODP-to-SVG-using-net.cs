using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OdpToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source ODP file
                var inputPath = "input.odp";

                // Directory to store generated SVG files
                var outputDirectory = "output_svg";
                Directory.CreateDirectory(outputDirectory);

                // Load the ODP presentation
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Convert each slide to SVG
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        var slide = presentation.Slides[index];
                        var svgPath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                        using (var fileStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation (required before exit)
                    var savedPath = "saved_output.pptx";
                    presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}