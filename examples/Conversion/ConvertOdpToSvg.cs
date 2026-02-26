using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source ODP file
        string inputPath = "presentation.odp";

        // Output file name pattern (slide number will be inserted)
        string outputPattern = "slide_{0}.svg";

        // Load the ODP presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Iterate through all slides and save each as an SVG file
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            string outputPath = string.Format(outputPattern, i + 1);
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                slide.WriteAsSvg(fileStream);
            }
        }

        // Save (dispose) the presentation before exiting
        presentation.Dispose();
    }
}