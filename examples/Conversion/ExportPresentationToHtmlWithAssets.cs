using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Output HTML file path
            string outputHtmlPath = "output.html";

            // CSS file path (referenced by the HTML)
            string cssFilePath = "styles.css";

            // CSS content to be written to the CSS file
            string cssContent = "body { font-family: Arial, sans-serif; }";

            // Ensure the output directory exists
            string outputDirectory = Path.GetDirectoryName(outputHtmlPath);
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Write the CSS file
            File.WriteAllText(cssFilePath, cssContent);

            // Create HTML export options and set the formatter to use the CSS file
            HtmlOptions htmlOptions = new HtmlOptions();
            htmlOptions.HtmlFormatter = HtmlFormatter.CreateSlideShowFormatter(cssFilePath, true);

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Save the presentation as HTML with external CSS and images
            presentation.Save(outputHtmlPath, SaveFormat.Html, htmlOptions);

            // Dispose the presentation before exiting
            presentation.Dispose();
        }
    }
}