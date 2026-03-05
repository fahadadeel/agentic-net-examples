using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string sourcePath = "input.pptx";
        // Path to the output PDF file
        string outputPath = "output.pdf";

        // Load the presentation from the file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Save the presentation in PDF format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}