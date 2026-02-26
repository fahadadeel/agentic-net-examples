using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string inputPath = "input.pptx";

        // Directory where SVG files will be saved
        string outputDir = "output";

        // Create output directory if it does not exist
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides and save each as an SVG file
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                string svgFilePath = Path.Combine(outputDir, $"slide_{index + 1}.svg");

                using (FileStream svgStream = File.Create(svgFilePath))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Save the presentation before exiting (optional, demonstrates saving)
            string savedPresentationPath = Path.Combine(outputDir, "saved.pptx");
            presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}