using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPT/PPTX file
        string inputPath = "input.pptx";

        // Folder where SVG files will be saved
        string outputFolder = "output_svg";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputFolder);

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Convert each slide to an SVG file
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            string svgFilePath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
            using (FileStream fileStream = File.Create(svgFilePath))
            {
                slide.WriteAsSvg(fileStream);
            }
        }

        // Save the presentation (required before exit)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}