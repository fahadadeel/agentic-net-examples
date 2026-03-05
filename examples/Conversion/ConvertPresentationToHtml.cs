using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Path where the HTML output will be saved
        string outputPath = "output.html";

        // Load the presentation from the PPTX file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in HTML format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html);
        }
    }
}