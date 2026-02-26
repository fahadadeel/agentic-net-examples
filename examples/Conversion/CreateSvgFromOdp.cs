using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgFromOdp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source ODP file
            string inputPath = "input.odp";

            // Directory where SVG files will be saved
            string outputDirectory = "output";

            // Ensure the output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Load the ODP presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides and save each as an SVG file
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    // Build the SVG file name for the current slide
                    string svgFilePath = Path.Combine(outputDirectory, $"slide_{slideIndex + 1}.svg");

                    // Create a file stream for the SVG output
                    using (FileStream svgStream = File.Create(svgFilePath))
                    {
                        // Write the slide content as SVG
                        presentation.Slides[slideIndex].WriteAsSvg(svgStream);
                    }
                }

                // Save the presentation before exiting (optional, can be same format)
                presentation.Save("output.odp", SaveFormat.Odp);
            }
        }
    }
}