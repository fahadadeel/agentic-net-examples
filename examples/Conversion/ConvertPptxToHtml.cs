using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Path for the generated HTML file
        string outputPath = "output.html";

        // Load the presentation from the PPTX file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Convert and save the presentation as HTML
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html);
        }
    }
}