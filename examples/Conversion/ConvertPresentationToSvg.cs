using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesSvgConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string sourcePath = "input.pptx";

            // Directory where SVG files will be saved
            string outputDirectory = "output_svgs";
            Directory.CreateDirectory(outputDirectory);

            // Load the presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Iterate through each slide in the presentation
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                    // Save the current slide as an SVG file
                    using (FileStream fileStream = File.Create(svgFilePath))
                    {
                        slide.WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation before exiting (as required by authoring rules)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
    }
}