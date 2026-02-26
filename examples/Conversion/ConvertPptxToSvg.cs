using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string sourcePath = "input.pptx";

            // Directory to store SVG files
            string outputDirectory = "svg_output";

            // Ensure the output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Iterate through all slides and save each as an SVG file
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[index];
                    string svgPath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                    using (FileStream fileStream = new FileStream(svgPath, FileMode.Create))
                    {
                        slide.WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation before exiting (optional, as per requirement)
                string savedPath = "saved_output.pptx";
                presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}