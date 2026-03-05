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
            // Path to the source ODP file
            string sourcePath = "input.odp";

            // Directory where SVG files will be saved
            string outputDirectory = "output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the ODP presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Iterate through all slides and save each as an SVG file
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                    using (FileStream fileStream = File.Create(svgFilePath))
                    {
                        // Write the current slide as SVG
                        slide.WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation before exiting (no modifications made)
                presentation.Save(sourcePath, SaveFormat.Odp);
            }
        }
    }
}