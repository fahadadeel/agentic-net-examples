using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output directory for SVG files
            string outputDir = "output";

            // Override paths if provided via command line arguments
            if (args.Length >= 1)
            {
                inputPath = args[0];
            }
            if (args.Length >= 2)
            {
                outputDir = args[1];
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through each slide and save as SVG
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                    using (FileStream outStream = new FileStream(svgPath, FileMode.Create))
                    {
                        // Write the current slide as SVG
                        pres.Slides[i].WriteAsSvg(outStream);
                    }
                }

                // Save the presentation before exiting (no modifications made)
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}