using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation (any supported format)
        string sourcePath = "input.pptx";
        // Path where the PDF will be saved
        string outputPath = "output.pdf";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Export the presentation to PDF format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}