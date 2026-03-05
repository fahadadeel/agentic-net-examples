using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = "input.pptx";
        // Output HTML file path
        string outputHtml = "output.html";
        // CSS file path
        string cssPath = "styles.css";

        // Write CSS content to the CSS file
        string cssContent = "body { font-family: Arial; }";
        File.WriteAllText(cssPath, cssContent);

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Configure HTML export options with a formatter that references the CSS file
        Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();
        options.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateSlideShowFormatter(cssPath, true);

        // Save the presentation as HTML (images will be saved as external resources)
        pres.Save(outputHtml, Aspose.Slides.Export.SaveFormat.Html, options);

        // Clean up
        pres.Dispose();
    }
}