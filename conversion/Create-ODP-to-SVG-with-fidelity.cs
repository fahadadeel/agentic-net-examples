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
            try
            {
                // Load the ODP presentation
                Presentation presentation = new Presentation("input.odp");

                // Iterate through all slides and export each as SVG
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    SVGOptions svgOptions = new SVGOptions();
                    // Use WYSIWYG settings for highest visual fidelity
                    svgOptions = SVGOptions.WYSIWYG;

                    string outputPath = $"slide_{i + 1}.svg";
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        slide.WriteAsSvg(fileStream, svgOptions);
                    }
                }

                // Save the presentation (no changes made) before exiting
                presentation.Save("output.odp", Aspose.Slides.Export.SaveFormat.Odp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}