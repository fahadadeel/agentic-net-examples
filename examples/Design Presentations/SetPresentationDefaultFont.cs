using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Define default regular font to be used when saving
        PdfOptions pdfOptions = new PdfOptions();
        pdfOptions.DefaultRegularFont = "Arial";

        // Save the presentation with the specified default font
        presentation.Save("DefaultFontPresentation.pdf", SaveFormat.Pdf, pdfOptions);
    }
}