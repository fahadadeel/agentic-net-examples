using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file
        string inputPath = "input.pptx";
        // Folder to store generated SVG files
        string outputFolder = "output";
        Directory.CreateDirectory(outputFolder);

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Create SVG conversion options
        Aspose.Slides.Export.SVGOptions svgOptions = new Aspose.Slides.Export.SVGOptions();
        // Example option: vectorize text
        svgOptions.VectorizeText = true;

        // Convert each slide to SVG using the options
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = pres.Slides[i];
            string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
            using (FileStream fs = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
            {
                slide.WriteAsSvg(fs, svgOptions);
            }
        }

        // Save the presentation before exiting (no modifications made)
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}