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
            Directory.CreateDirectory(outputFolder);
            using (Presentation pres = new Presentation(inputPath))
            {
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                    using (FileStream fs = File.Create(svgPath))
                    {
                        slide.WriteAsSvg(fs);
                    }
                }
                // Save the presentation before exiting
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}