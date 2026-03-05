using System;
using System.IO;

namespace SvgExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation from a file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Iterate through all slides in the presentation
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[index];
                    string svgFileName = $"slide_{index + 1}.svg";

                    // Create a file stream for the SVG output
                    using (FileStream svgStream = File.Create(svgFileName))
                    {
                        // Save the current slide as an SVG file
                        slide.WriteAsSvg(svgStream);
                    }
                }

                // Save the (potentially unchanged) presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}