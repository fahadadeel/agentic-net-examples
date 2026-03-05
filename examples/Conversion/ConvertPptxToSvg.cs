using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PPTXToSVGConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            string inputPath = "input.pptx";

            // Output directory for SVG files
            string outputDirectory = "output_svg";

            // Ensure the output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides and save each as SVG
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    string svgFilePath = Path.Combine(outputDirectory, $"slide_{slideIndex + 1}.svg");

                    using (FileStream svgStream = File.Create(svgFilePath))
                    {
                        slide.WriteAsSvg(svgStream);
                    }
                }

                // Save the (potentially unchanged) presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}