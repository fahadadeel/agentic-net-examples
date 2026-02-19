using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path
        System.String inputPath = "input.pptx";

        // Output HTML file path
        System.String outputHtml = "output.html";

        // CSS file path to be referenced from the HTML
        System.String cssPath = "styles.css";

        // CSS content to be written to the CSS file
        System.String cssContent = "/* CSS content */";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Write CSS file
        File.WriteAllText(cssPath, cssContent);

        // Set HTML export options with a custom formatter that references the CSS file
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
        htmlOptions.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateSlideShowFormatter(cssPath, true);

        // Export presentation to HTML (CSS and images will be saved separately)
        presentation.Save(outputHtml, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Dispose the presentation object
        presentation.Dispose();
    }
}