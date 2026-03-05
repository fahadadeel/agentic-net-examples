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

        // Directory where SVG files will be saved
        string outputDirectory = "output_svg";

        // Create the output directory if it does not exist
        Directory.CreateDirectory(outputDirectory);

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides and convert each to an SVG file
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                // Get the current slide
                Aspose.Slides.ISlide slide = presentation.Slides[index];

                // Build the SVG file path for the current slide
                string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                // Write the slide as SVG
                using (FileStream fileStream = File.Create(svgFilePath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation before exiting (optional, demonstrates lifecycle compliance)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}