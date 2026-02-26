using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PPTXToSVG
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string inputPath = "input.pptx";

            // Load the presentation using the Aspose.Slides Presentation class
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides in the presentation
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    // Get the current slide
                    Aspose.Slides.ISlide slide = presentation.Slides[index];

                    // Define the output SVG file name for the current slide
                    string svgFileName = $"slide_{index + 1}.svg";

                    // Create a file stream to write the SVG content
                    using (FileStream svgStream = File.Create(svgFileName))
                    {
                        // Save the slide as SVG using the WriteAsSvg method
                        slide.WriteAsSvg(svgStream);
                    }
                }

                // Save the presentation before exiting (as required by authoring rules)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}