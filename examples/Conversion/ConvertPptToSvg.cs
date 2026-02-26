using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Verify that an input file path is provided
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: ConvertPptToSvg <input-ppt-file>");
            return;
        }

        // Path to the source PowerPoint file
        string inputPath = args[0];

        // Load the presentation from the specified file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Convert each slide to an individual SVG file
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), $"slide_{i + 1}.svg");

            using (FileStream fileStream = File.Create(outputPath))
            {
                slide.WriteAsSvg(fileStream);
            }
        }

        // Save the presentation (required before exiting)
        presentation.Save(inputPath, SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}