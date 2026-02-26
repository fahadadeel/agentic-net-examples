using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PowerPoint presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Convert each slide to an SVG file
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            // Create a file stream for the SVG output
            using (FileStream svgStream = File.Create($"slide_{i + 1}.svg"))
            {
                // Write the current slide as SVG
                pres.Slides[i].WriteAsSvg(svgStream);
            }
        }

        // Save the (unchanged) presentation before exiting
        pres.Save("output.pptx", SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}