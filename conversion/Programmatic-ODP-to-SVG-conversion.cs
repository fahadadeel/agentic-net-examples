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
            string inputPath = "input.odp";
            string outputFolder = "output_svg";

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            using (Presentation presentation = new Presentation(inputPath))
            {
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                    using (FileStream fileStream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
                    {
                        slide.WriteAsSvg(fileStream);
                    }
                }

                string savedPath = "converted.pptx";
                presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}