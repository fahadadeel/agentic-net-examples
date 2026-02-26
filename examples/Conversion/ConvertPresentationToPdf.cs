using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the PowerPoint presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Configure PDF options to include hidden slides
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.ShowHiddenSlides = true;

        // Save the presentation as PDF with the specified options
        presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Clean up resources
        presentation.Dispose();
    }
}