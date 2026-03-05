using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Create a file stream for the SVG output
            using (FileStream svgStream = File.Create("slide_1.svg"))
            {
                // Export the first slide as SVG
                presentation.Slides[0].WriteAsSvg(svgStream);
            }

            // Save the presentation before exiting (optional, demonstrates save lifecycle)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}