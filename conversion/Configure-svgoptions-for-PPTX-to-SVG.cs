using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the PPTX presentation
            Presentation presentation = new Presentation("input.pptx");

            // Create SVG options (most accurate) and customize as needed
            SVGOptions svgOptions = SVGOptions.WYSIWYG;
            svgOptions.VectorizeText = true;

            // Export each slide to an individual SVG file
            int slideCount = presentation.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                string outputPath = $"slide_{i + 1}.svg";
                using (FileStream fileStream = File.Create(outputPath))
                {
                    presentation.Slides[i].WriteAsSvg(fileStream, svgOptions);
                }
            }

            // Save the presentation (no modifications) before exiting
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}