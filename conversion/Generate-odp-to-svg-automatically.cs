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
            // Path to the source ODP file
            string inputPath = "input.odp";

            // Directory where SVG files will be saved
            string outputDir = "output_svg";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the ODP presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides and export each as SVG
                int slideCount = presentation.Slides.Count;
                for (int i = 0; i < slideCount; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                    using (FileStream fileStream = File.Create(svgPath))
                    {
                        slide.WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation (optional) before exiting
                string savedPath = "saved_output.pptx";
                presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}