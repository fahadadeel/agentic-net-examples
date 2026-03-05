using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Define PDF save options with a default regular font
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.DefaultRegularFont = "Arial";

        // Save the presentation using the specified options
        presentation.Save("DefaultFontPresentation.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
    }
}