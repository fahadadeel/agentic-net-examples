using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the source presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

            // Create a file stream for the SVG output
            using (FileStream fileStream = File.Create("slide_1.svg"))
            {
                // Convert the first slide to SVG
                pres.Slides[0].WriteAsSvg(fileStream);
            }

            // Save the presentation before exiting (optional output file)
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
    }
}