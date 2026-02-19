using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OdpToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default input and output paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.odp");
            string outputPath = Path.Combine(dataDir, "output.html");

            // Override with command‑line arguments if provided
            if (args.Length >= 1)
            {
                inputPath = args[0];
            }
            if (args.Length >= 2)
            {
                outputPath = args[1];
            }

            // Load the ODP presentation
            Presentation pres = new Presentation(inputPath);

            // Configure HTML export to use SVG for slide images
            HtmlOptions htmlOptions = new HtmlOptions();
            htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());

            // Save the presentation as HTML containing SVG images
            pres.Save(outputPath, SaveFormat.Html, htmlOptions);
        }
    }
}