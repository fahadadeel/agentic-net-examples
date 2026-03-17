using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";

            // Directory to store SVG files
            string outputDir = "SvgSlides";

            try
            {
                // Ensure output directory exists
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides and save each as SVG
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");

                        using (FileStream svgStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(svgStream);
                        }
                    }

                    // Save the presentation (optional, ensures any changes are persisted)
                    string savedPath = "output.pptx";
                    presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("SVG export completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}