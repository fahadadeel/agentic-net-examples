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
            // Path to save the (unchanged) presentation after processing
            string destinationPath = "output.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Iterate through each slide and export it as an SVG file
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    // Get the current slide
                    Aspose.Slides.ISlide slide = presentation.Slides[index];
                    // Define the SVG file name for this slide
                    string svgFileName = $"slide_{index + 1}.svg";

                    // Create a file stream for the SVG output
                    using (Stream svgStream = File.Create(svgFileName))
                    {
                        // Write the slide content to the SVG stream
                        slide.WriteAsSvg(svgStream);
                    }
                }

                // Save the (potentially modified) presentation before exiting
                presentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}