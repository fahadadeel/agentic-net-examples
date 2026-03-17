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
            Directory.CreateDirectory(outputDirectory);

            using (Presentation pres = new Presentation(inputPath))
            {
                for (int index = 0; index < pres.Slides.Count; index++)
                {
                    string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");
                    using (FileStream fileStream = File.Create(svgFilePath))
                    {
                        pres.Slides[index].WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation before exiting (optional)
                pres.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}