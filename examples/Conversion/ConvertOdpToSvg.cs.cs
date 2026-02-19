using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OdpToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and file paths
            string dataDir = @"C:\Data";
            string inputOdpPath = Path.Combine(dataDir, "input.odp");
            string outputSvgPath = Path.Combine(dataDir, "output.svg");
            string outputPptxPath = Path.Combine(dataDir, "output.pptx");

            // Load the ODP presentation
            Presentation pres = new Presentation(inputOdpPath);

            // Export the first slide as SVG
            using (FileStream svgStream = new FileStream(outputSvgPath, FileMode.Create))
            {
                pres.Slides[0].WriteAsSvg(svgStream);
            }

            // Save the presentation (required before exit)
            pres.Save(outputPptxPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}