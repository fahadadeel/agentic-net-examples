using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        System.String inputPath = "input.pptx";
        // Path to the output HTML file
        System.String outputPath = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Configure HTML export options
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
        // Enable responsive layout (optional)
        htmlOptions.SvgResponsiveLayout = true;
        // Set JPEG quality to maximum for high‑quality images
        htmlOptions.JpegQuality = 100;

        // Save the presentation as HTML with the specified options
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Dispose the presentation object
        presentation.Dispose();
    }
}