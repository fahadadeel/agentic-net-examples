using System;
using System.IO;
using Aspose.Slides;

namespace SlideToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string sourcePath = "input.pptx";

            // Load the presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    // Get the current slide
                    ISlide slide = presentation.Slides[i];

                    // Define output SVG file name
                    string svgPath = $"slide_{i + 1}.svg";

                    // Create a file stream for the SVG output
                    using (FileStream svgStream = File.Create(svgPath))
                    {
                        // Save the slide as SVG
                        slide.WriteAsSvg(svgStream);
                    }
                }

                // Save the presentation (no changes made, but required by rules)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}