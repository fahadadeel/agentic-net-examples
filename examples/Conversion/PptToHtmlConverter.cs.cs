using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPT or PPTX file
        string inputPath = "input.pptx";
        // Path where the HTML output will be saved
        string outputPath = "output.html";

        // Load the presentation from the specified file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Create HTML export options (default options)
        Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();

        // Save the presentation as HTML using the specified options
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, options);

        // Release resources
        pres.Dispose();
    }
}