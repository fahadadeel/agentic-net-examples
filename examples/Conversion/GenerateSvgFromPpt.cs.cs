using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GenerateSvgFromPpt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the directory containing the input PPTX and the output HTML file
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPptxPath = Path.Combine(dataDir, "input.pptx");
            string outputHtmlPath = Path.Combine(dataDir, "output.html");

            // Load the presentation from the PPTX file
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPptxPath))
            {
                // Configure HTML export options to generate SVG images for each slide
                Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
                htmlOptions.SlideImageFormat = Aspose.Slides.Export.SlideImageFormat.Svg(new Aspose.Slides.Export.SVGOptions());

                // Save the presentation as an HTML file; the slides will be embedded as SVG
                pres.Save(outputHtmlPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
            }

            // Indicate completion
            Console.WriteLine("SVG export completed. Output saved to: " + outputHtmlPath);
        }
    }
}