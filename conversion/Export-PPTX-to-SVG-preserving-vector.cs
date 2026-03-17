using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation pres = new Presentation("input.pptx");

                // Iterate through each slide and save as SVG
                for (int index = 0; index < pres.Slides.Count; index++)
                {
                    ISlide slide = pres.Slides[index];
                    string svgPath = $"slide_{index + 1}.svg";

                    using (FileStream svgStream = File.Create(svgPath))
                    {
                        SVGOptions options = new SVGOptions();
                        options.VectorizeText = true; // Preserve vector fidelity
                        slide.WriteAsSvg(svgStream, options);
                    }
                }

                // Save the presentation before exiting (optional rewrite)
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}