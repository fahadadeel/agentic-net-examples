using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source ODP file
        string inputFile = "input.odp";

        // Load the ODP presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

        // Convert each slide to an individual SVG file
        for (int index = 0; index < presentation.Slides.Count; index++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[index];
            string svgFile = $"slide_{index + 1}.svg";

            using (FileStream svgStream = File.Create(svgFile))
            {
                slide.WriteAsSvg(svgStream);
            }
        }

        // Save the presentation before exiting (rewriting the original file)
        presentation.Save("output.odp", SaveFormat.Odp);

        // Release resources
        presentation.Dispose();
    }
}