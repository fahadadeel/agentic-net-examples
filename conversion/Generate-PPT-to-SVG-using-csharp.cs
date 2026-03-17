using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputDir = "output_svg";

                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (Presentation presentation = new Presentation(inputPath))
                {
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                        using (FileStream fileStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation before exiting
                    string savedPath = Path.Combine(outputDir, "saved.pptx");
                    presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}