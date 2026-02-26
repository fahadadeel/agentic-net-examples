using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Export to PDF with ink visible
        Aspose.Slides.Export.PdfOptions pdfOptionsShowInk = new Aspose.Slides.Export.PdfOptions();
        pdfOptionsShowInk.InkOptions.HideInk = false;
        presentation.Save("output_show_ink.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptionsShowInk);

        // Export to PDF with ink hidden
        Aspose.Slides.Export.PdfOptions pdfOptionsHideInk = new Aspose.Slides.Export.PdfOptions();
        pdfOptionsHideInk.InkOptions.HideInk = true;
        presentation.Save("output_hide_ink.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptionsHideInk);

        // Save the original presentation (ensuring it is saved before exit)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}