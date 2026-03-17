using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PowerPoint file
                string inputPath = "input.pptx";

                // Output HTML file
                string outputPath = "output.html";

                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Set up HTML export options with embedded fonts
                HtmlOptions htmlOptions = new HtmlOptions();
                EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController();
                htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController);

                // Save as HTML
                presentation.Save(outputPath, SaveFormat.Html, htmlOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}