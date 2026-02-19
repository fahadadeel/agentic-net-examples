using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        System.String inputPath = "input.pptx";
        // Path where the HTML output will be saved
        System.String outputPath = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Configure HTML export options with responsive SVG layout
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
        htmlOptions.SvgResponsiveLayout = true;

        // Save the presentation as HTML
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Release resources
        presentation.Dispose();
    }
}