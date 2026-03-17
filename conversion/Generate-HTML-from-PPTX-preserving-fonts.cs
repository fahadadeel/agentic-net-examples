using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation from a file
                Presentation presentation = new Presentation("input.pptx");

                // Set up HTML export options to embed all fonts
                HtmlOptions htmlOptions = new HtmlOptions();
                htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new EmbedAllFontsHtmlController());

                // Save the presentation as HTML with embedded fonts
                presentation.Save("output.html", SaveFormat.Html, htmlOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}