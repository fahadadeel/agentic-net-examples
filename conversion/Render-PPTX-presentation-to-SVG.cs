using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string inputPath = "sample.pptx";

                // Directory to store generated SVG files
                string outputDirectory = "output_svgs";
                Directory.CreateDirectory(outputDirectory);

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                        // Save each slide as an SVG file
                        using (FileStream fileStream = File.Create(svgFilePath))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation before exiting (optional, ensures any changes are persisted)
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}