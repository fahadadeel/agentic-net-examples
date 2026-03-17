using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputDirectory = "output_svgs";

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            using (Presentation presentation = new Presentation(inputPath))
            {
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");
                    using (FileStream fileStream = File.Create(svgFilePath))
                    {
                        presentation.Slides[index].WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation before exiting
                string savedPresentationPath = "saved_output.pptx";
                presentation.Save(savedPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}