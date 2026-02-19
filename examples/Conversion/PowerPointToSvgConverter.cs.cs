using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Output HTML file path containing SVG images (second argument or default)
            string outputPath = args.Length > 1 ? args[1] : "output.html";

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Configure HTML export options to use SVG for slide images
            HtmlOptions htmlOptions = new HtmlOptions();
            htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());

            // Save the presentation as HTML with embedded SVG images
            pres.Save(outputPath, SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            pres.Dispose();
        }
    }
}