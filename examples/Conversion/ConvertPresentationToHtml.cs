using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create an HTML formatter with custom CSS and slide titles enabled
        Aspose.Slides.Export.HtmlFormatter formatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter("custom.css", true);

        // Configure HTML export options
        Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();
        options.HtmlFormatter = formatter;

        // Save the presentation as HTML using the custom formatter
        presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, options);

        // Ensure the presentation is saved (already saved as HTML) and release resources
        presentation.Dispose();
    }
}