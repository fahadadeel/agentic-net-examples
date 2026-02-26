using System;

class Program
{
    static void Main()
    {
        // Path to the source PowerPoint file
        System.String inputPath = "input.pptx";
        // Path where the HTML output will be saved
        System.String outputPath = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Configure HTML export options
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
        // Enable responsive SVG layout
        htmlOptions.SvgResponsiveLayout = true;
        // Set picture compression to 150 DPI for high‑quality images
        htmlOptions.PicturesCompression = Aspose.Slides.Export.PicturesCompression.Dpi150;

        // Save the presentation as HTML with the specified options
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Release resources
        presentation.Dispose();
    }
}