using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PowerPoint presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Iterate through each slide in the presentation
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                // Get the current slide
                Aspose.Slides.ISlide slide = presentation.Slides[index];

                // Define the output SVG file name
                string svgFilePath = $"slide_{index + 1}.svg";

                // Create a file stream for the SVG output
                using (FileStream svgStream = File.Create(svgFilePath))
                {
                    // Save the slide as SVG
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Save the (potentially modified) presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}