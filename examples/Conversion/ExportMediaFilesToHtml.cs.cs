using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        System.String dataDir = "Data";
        System.String inputFile = System.IO.Path.Combine(dataDir, "sample.pptx");
        System.String outputDir = "ExportedHtml";
        System.IO.Directory.CreateDirectory(outputDir);
        const System.String htmlFileName = "output.html";
        const System.String baseUri = "";

        // Create controller for exporting media files
        Aspose.Slides.Export.VideoPlayerHtmlController controller = new Aspose.Slides.Export.VideoPlayerHtmlController(outputDir, htmlFileName, baseUri);
        // Set HTML options with custom formatter
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions(controller);
        Aspose.Slides.Export.SVGOptions svgOptions = new Aspose.Slides.Export.SVGOptions(controller);
        htmlOptions.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateCustomFormatter(controller);
        htmlOptions.SlideImageFormat = Aspose.Slides.Export.SlideImageFormat.Svg(svgOptions);

        // Load presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile);
        // Save presentation to HTML with media files
        pres.Save(System.IO.Path.Combine(outputDir, htmlFileName), Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
        // Dispose presentation
        pres.Dispose();
    }
}