using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Configure PDF save options with default font set to Arial
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.DefaultRegularFont = "Arial";

            // Save the presentation using the configured options
            presentation.Save("DefaultFontPresentation.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
    }
}