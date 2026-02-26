using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string sourcePath = "input.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath))
            {
                // Iterate through all slides and save each as an SVG file
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    // Get the current slide
                    Aspose.Slides.ISlide slide = pres.Slides[i];

                    // Define the output SVG file name
                    string svgPath = $"slide_{i + 1}.svg";

                    // Create a file stream for the SVG output
                    using (FileStream fs = File.Create(svgPath))
                    {
                        // Write the slide content as SVG
                        slide.WriteAsSvg(fs);
                    }
                }

                // Save the presentation before exiting (optional, as no changes were made)
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}