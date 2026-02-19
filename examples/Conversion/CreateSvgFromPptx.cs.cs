using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        System.String inputPath = "input.pptx";
        // Path to save the (unchanged) PPTX after processing
        System.String outputPptxPath = "output.pptx";
        // Directory where SVG files will be stored
        System.String svgOutputDir = "SvgOutput";

        // Ensure the SVG output directory exists
        Directory.CreateDirectory(svgOutputDir);

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Export each slide to an individual SVG file
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            System.String svgPath = Path.Combine(svgOutputDir, "slide_" + (i + 1) + ".svg");
            using (FileStream outStream = new FileStream(svgPath, FileMode.Create))
            {
                pres.Slides[i].WriteAsSvg(outStream);
            }
        }

        // Save the presentation before exiting (as required)
        pres.Save(outputPptxPath, SaveFormat.Pptx);
    }
}