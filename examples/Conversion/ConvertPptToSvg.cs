using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string sourcePath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Iterate through each slide and save it as an SVG file
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                string svgPath = $"slide_{i + 1}.svg";

                using (FileStream fileStream = File.Create(svgPath))
                {
                    // Convert the current slide to SVG
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation before exiting (required by the rules)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}