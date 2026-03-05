using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string sourcePath = "input.pptx";

        // Directory where SVG files will be saved
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // Load the presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath))
        {
            // Iterate through all slides and save each as SVG
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");

                using (FileStream fs = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fs);
                }
            }

            // Save the presentation before exiting (optional if no changes were made)
            pres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}