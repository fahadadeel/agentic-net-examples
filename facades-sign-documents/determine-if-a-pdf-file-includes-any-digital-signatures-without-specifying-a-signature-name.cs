using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Path to the PDF file to be examined
        const string pdfPath = "input.pdf";

        if (!File.Exists(pdfPath))
        {
            Console.Error.WriteLine($"File not found: {pdfPath}");
            return;
        }

        // Use PdfFileSignature facade to work with signatures
        using (PdfFileSignature pdfSign = new PdfFileSignature())
        {
            // Bind the PDF file; this loads the document into the facade
            pdfSign.BindPdf(pdfPath);

            // Check whether the PDF contains any digital signature
            bool hasSignature = pdfSign.ContainsSignature();

            Console.WriteLine(hasSignature
                ? "The PDF contains at least one digital signature."
                : "The PDF does not contain any digital signatures.");
        }
    }
}