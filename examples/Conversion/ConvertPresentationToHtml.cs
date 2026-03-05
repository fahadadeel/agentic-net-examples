using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the source presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create an HTML formatter with a custom CSS file and enable slide titles
        Aspose.Slides.Export.HtmlFormatter formatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter("style.css", true);

        // Configure HTML export options and assign the formatter
        Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();
        options.HtmlFormatter = formatter;

        // Export the presentation to a single HTML file using the specified options
        presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, options);

        // Save the presentation before exiting (as required)
        presentation.Save("input_saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}