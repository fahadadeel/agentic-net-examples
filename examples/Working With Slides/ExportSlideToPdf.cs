using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create PDF export options (default options)
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

        // Export the presentation (all slides) to a PDF file
        presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Save the presentation before exiting (no modifications made)
        presentation.Save("input.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}