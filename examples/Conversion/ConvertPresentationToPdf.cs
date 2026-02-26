using System;

class Program
{
    static void Main()
    {
        // Load the PowerPoint presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Create PDF options and set password protection
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.Password = "pdfPassword";
            pdfOptions.AccessPermissions = Aspose.Slides.Export.PdfAccessPermissions.PrintDocument | Aspose.Slides.Export.PdfAccessPermissions.HighQualityPrint;

            // Save the presentation as a password-protected PDF
            presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
    }
}