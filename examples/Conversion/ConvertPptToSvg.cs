using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string inputPath = "input.pptx";

        // Directory where SVG files will be saved
        string outputDirectory = "output_svgs";
        Directory.CreateDirectory(outputDirectory);

        // Load the presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through each slide and save as SVG
            int slideCount = pres.Slides.Count;
            for (int index = 0; index < slideCount; index++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[index];
                string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");
                using (FileStream fileStream = File.Create(svgFilePath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation before exiting (optional copy)
            string savedPresentationPath = "saved_output.pptx";
            pres.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}