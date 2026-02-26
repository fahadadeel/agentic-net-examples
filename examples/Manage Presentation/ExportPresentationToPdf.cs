using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";
        // Path for the resulting PDF file
        string outputPath = "output.pdf";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Export to PDF format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
        // Presentation is disposed automatically by the using block
    }
}