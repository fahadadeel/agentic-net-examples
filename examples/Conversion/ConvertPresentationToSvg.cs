using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file path
        string inputPath = "input.pptx";
        // Output folder for SVG files
        string outputFolder = "SvgOutput";

        // Ensure output directory exists
        Directory.CreateDirectory(outputFolder);

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Iterate through all slides and save each as SVG
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                ISlide slide = pres.Slides[i];
                string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                using (Stream svgStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Save the presentation before exiting (as required)
            string savedPath = "output_saved.pptx";
            pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}