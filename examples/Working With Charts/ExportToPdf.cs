using System;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create PDF export options (optional, can be customized)
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

        // Export the presentation to PDF format
        presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Release resources
        presentation.Dispose();
    }
}