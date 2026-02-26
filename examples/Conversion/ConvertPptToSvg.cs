using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string inputPath = "input.pptx";

        // Directory to store generated SVG files
        string outputDir = "output_svgs";

        // Create output directory if it does not exist
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through each slide and save as SVG
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (FileStream fileStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation before exiting (optional, demonstrates saving)
            string savedPath = "saved_output.pptx";
            presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}