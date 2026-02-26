using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string sourcePath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Iterate through all slides
            int slideCount = presentation.Slides.Count;
            for (int index = 0; index < slideCount; index++)
            {
                // Get the current slide
                Aspose.Slides.ISlide slide = presentation.Slides[index];

                // Define SVG output file name
                string svgPath = $"slide_{index + 1}.svg";

                // Save the slide as SVG
                using (FileStream svgStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Save the (unchanged) presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}