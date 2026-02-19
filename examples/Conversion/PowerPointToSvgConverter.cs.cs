using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;

namespace PowerPointToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path (default)
            string inputPath = "input.pptx";
            // Output directory for SVG files (default)
            string outputDirectory = "output";

            // Override defaults with command line arguments if provided
            if (args.Length >= 1)
            {
                inputPath = args[0];
            }
            if (args.Length >= 2)
            {
                outputDirectory = args[1];
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Iterate through each slide and save as SVG
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                string svgFilePath = Path.Combine(outputDirectory, $"slide_{slideIndex + 1}.svg");
                using (FileStream fileStream = new FileStream(svgFilePath, FileMode.Create))
                {
                    // Write the slide as SVG to the file stream
                    presentation.Slides[slideIndex].WriteAsSvg(fileStream);
                }
            }

            // Save a copy of the presentation before exiting (as required)
            string copyPath = Path.Combine(outputDirectory, "copy.pptx");
            presentation.Save(copyPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}