using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Create an EmbedAllFontsHtmlController with no font exclusions
        string[] fontExclude = new string[0];
        Aspose.Slides.Export.EmbedAllFontsHtmlController embedController = new Aspose.Slides.Export.EmbedAllFontsHtmlController(fontExclude);

        // Configure HTML export options with the custom formatter
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions
        {
            HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateCustomFormatter(embedController)
        };

        // Save the presentation as HTML with embedded fonts
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Clean up
        pres.Dispose();
    }
}