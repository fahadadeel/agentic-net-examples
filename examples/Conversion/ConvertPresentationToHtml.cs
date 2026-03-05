using System;

namespace ConvertPresentationToHtml
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

            // Create a controller that embeds all fonts in WOFF format
            Aspose.Slides.Export.EmbedAllFontsHtmlController embedController =
                new Aspose.Slides.Export.EmbedAllFontsHtmlController(fontExclude);

            // Configure HTML export options with the custom formatter
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions
            {
                HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateCustomFormatter(embedController)
            };

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Save the presentation as HTML with embedded fonts
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Release resources
            presentation.Dispose();
        }
    }
}