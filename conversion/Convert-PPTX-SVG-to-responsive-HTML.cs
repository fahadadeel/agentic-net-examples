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
            // Paths for input presentation and output HTML
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Create HTML export options
                HtmlOptions options = new HtmlOptions();

                // Enable responsive layout for SVG images
                options.SvgResponsiveLayout = true;

                // Export slides as SVG
                SVGOptions svgOpts = new SVGOptions();
                options.SlideImageFormat = SlideImageFormat.Svg(svgOpts);

                // Save the presentation as responsive HTML
                pres.Save(outputPath, SaveFormat.Html, options);
            }
        }
        catch (Exception ex)
        {
            // Output any errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}