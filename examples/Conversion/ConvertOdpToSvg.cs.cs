using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertOdpToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input ODP file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.odp";

            // Output directory for SVG files (second argument or default)
            string outputDir = args.Length > 1 ? args[1] : "output";

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the ODP presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide and save as SVG
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");

                using (FileStream outStream = new FileStream(svgPath, FileMode.Create))
                {
                    slide.WriteAsSvg(outStream);
                }
            }

            // Save the presentation (required by authoring rules)
            pres.Save(inputPath, SaveFormat.Odp);
        }
    }
}