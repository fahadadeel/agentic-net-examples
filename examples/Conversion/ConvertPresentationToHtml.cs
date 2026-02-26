using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        System.String inputPath = "input.pptx";
        // Path where the HTML output will be saved
        System.String outputPath = "output.html";
        // Path or URL to the CSS file that defines the new style
        System.String cssPath = "style.css";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Configure HTML export options with a custom formatter that uses the CSS file
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
        htmlOptions.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter(cssPath, true);

        // Save the presentation as HTML using the new CSS style
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Release resources
        presentation.Dispose();
    }
}