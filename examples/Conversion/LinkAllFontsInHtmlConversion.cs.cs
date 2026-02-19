using System;

namespace AsposeSlidesHtmlConversion
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

            // Create a controller that embeds all fonts in WOFF format
            Aspose.Slides.Export.EmbedAllFontsHtmlController embedController =
                new Aspose.Slides.Export.EmbedAllFontsHtmlController(fontExclude);

            // Configure HTML export options with a custom formatter using the controller
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions
            {
                HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateCustomFormatter(embedController)
            };

            // Load the presentation
            Aspose.Slides.Presentation presentation =
                new Aspose.Slides.Presentation(inputPath);

            // Save the presentation as HTML with linked fonts
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}