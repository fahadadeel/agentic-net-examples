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
            string outputFolder = "output_svgs";

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            using (Presentation presentation = new Presentation(inputPath))
            {
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                    using (FileStream fileStream = File.Create(svgPath))
                    {
                        presentation.Slides[i].WriteAsSvg(fileStream);
                    }
                }

                string savedPath = "saved_output.pptx";
                presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}