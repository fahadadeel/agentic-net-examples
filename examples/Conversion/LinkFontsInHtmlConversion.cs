using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";

            // Output HTML file path
            string outputPath = "output.html";

            // No fonts are excluded from embedding
            string[] fontExclude = new string[0];

            // Create an EmbedAllFontsHtmlController with the exclusion list
            EmbedAllFontsHtmlController embedController = new EmbedAllFontsHtmlController(fontExclude);

            // Configure HtmlOptions to use the custom formatter with the embed controller
            HtmlOptions htmlOptions = new HtmlOptions()
            {
                HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedController)
            };

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Save the presentation as HTML with all fonts embedded
            presentation.Save(outputPath, SaveFormat.Html, htmlOptions);

            // Dispose the presentation to release resources
            presentation.Dispose();
        }
    }
}