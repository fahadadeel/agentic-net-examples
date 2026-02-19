using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input presentation and output file paths
        string inputPath = "input.pptx";
        string outputSvgPath = "slide.svg";
        string outputPptxPath = "output.pptx";

        // Override paths with command line arguments if provided
        if (args.Length >= 1)
        {
            inputPath = args[0];
        }
        if (args.Length >= 2)
        {
            outputSvgPath = args[1];
        }
        if (args.Length >= 3)
        {
            outputPptxPath = args[2];
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Render the first slide as an SVG image
        using (FileStream outStream = new FileStream(outputSvgPath, FileMode.Create))
        {
            pres.Slides[0].WriteAsSvg(outStream);
        }

        // Save the presentation before exiting
        pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}