using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportMediaToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            Presentation presentation = new Presentation("input.pptx");

            // Create HTML export options (default options)
            HtmlOptions htmlOptions = new HtmlOptions();

            // Export the presentation to HTML format, which also extracts media files
            presentation.Save("output.html", SaveFormat.Html, htmlOptions);
        }
    }
}