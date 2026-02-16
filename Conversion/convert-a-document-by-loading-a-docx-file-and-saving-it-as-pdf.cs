using System;
using Aspose.Words;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Path to the source DOCX file.
        string docxPath = @"C:\Input\sample.docx";

        // Path where the resulting PDF will be saved.
        string pdfPath = @"C:\Output\sample.pdf";

        // Load the DOCX document.
        Document document = new Document(docxPath);

        // Create PDF save options (optional – can be customized if needed).
        PdfSaveOptions pdfOptions = new PdfSaveOptions();

        // Save the document as PDF using the specified options.
        document.Save(pdfPath, pdfOptions);
    }
}
