using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Path where the HTML output will be saved
        string outputPath = "output.html";

        // Load the presentation from the PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        // Convert and save the presentation as HTML
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html);
        // Ensure resources are released
        presentation.Dispose();
    }
}