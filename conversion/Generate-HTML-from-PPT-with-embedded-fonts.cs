using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load the PowerPoint presentation
            Presentation presentation = new Presentation("input.pptx");

            // Create a controller that embeds all fonts in WOFF format
            EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController();

            // Create a custom HTML formatter using the font controller
            HtmlFormatter customFormatter = HtmlFormatter.CreateCustomFormatter(fontController);

            // Set up HTML export options and assign the custom formatter
            HtmlOptions htmlOptions = new HtmlOptions();
            htmlOptions.HtmlFormatter = customFormatter;

            // Save the presentation as HTML with embedded fonts
            presentation.Save("output.html", SaveFormat.Html, htmlOptions);
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}