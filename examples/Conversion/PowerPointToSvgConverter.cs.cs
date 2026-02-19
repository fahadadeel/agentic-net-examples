using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file path
        string inputPath = "input.pptx";
        // Output directory for SVG files
        string outputDirectory = "output";

        // Override defaults with command‑line arguments if provided
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
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through each slide and save it as an SVG file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                string svgFilePath = Path.Combine(outputDirectory, $"slide_{i + 1}.svg");
                using (FileStream svgStream = new FileStream(svgFilePath, FileMode.Create))
                {
                    // Write the slide content to the SVG stream
                    pres.Slides[i].WriteAsSvg(svgStream);
                }
            }

            // Save the (unchanged) presentation before exiting, as required
            string presentationOutputPath = Path.Combine(outputDirectory, "output.pptx");
            pres.Save(presentationOutputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}