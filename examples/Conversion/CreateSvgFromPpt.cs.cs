using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";

        // Directory where SVG files will be saved
        string outDir = "output";
        if (!Directory.Exists(outDir))
        {
            Directory.CreateDirectory(outDir);
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Export each slide to an individual SVG file
        int slideIndex = 0;
        while (slideIndex < pres.Slides.Count)
        {
            string svgPath = Path.Combine(outDir, $"slide_{slideIndex + 1}.svg");
            using (FileStream fs = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
            {
                pres.Slides[slideIndex].WriteAsSvg(fs);
            }
            slideIndex++;
        }

        // Save the presentation before exiting (no modifications made)
        string outputPptx = Path.Combine(outDir, "output.pptx");
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}