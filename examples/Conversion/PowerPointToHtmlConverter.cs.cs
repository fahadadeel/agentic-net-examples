using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Fonts to exclude from linking (none in this example)
            string[] fontExclude = new string[0];

            // Create a controller that links all fonts in the presentation
            EmbedAllFontsHtmlController embedController = new EmbedAllFontsHtmlController(fontExclude);

            // Set up HTML export options with a custom formatter using the controller
            HtmlOptions htmlOptions = new HtmlOptions
            {
                HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedController)
            };

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Save the presentation as HTML with linked fonts
            presentation.Save(outputPath, SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}