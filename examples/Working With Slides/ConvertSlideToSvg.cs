using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string sourcePath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Iterate through each slide in the presentation
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                // Define the SVG output file name for the current slide
                string svgFilePath = $"slide_{index + 1}.svg";

                // Create a file stream to write the SVG content
                using (FileStream svgStream = File.Create(svgFilePath))
                {
                    // Convert the current slide to SVG and write to the stream
                    presentation.Slides[index].WriteAsSvg(svgStream);
                }
            }

            // Save the (unchanged) presentation before exiting
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}