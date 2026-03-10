using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPath = "signed_form.pdf";
        const string outputPath = "unsigned_form.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // PdfFileSignature facade handles signature removal while keeping form fields intact.
        using (PdfFileSignature pdfSign = new PdfFileSignature())
        {
            // Load the PDF document.
            pdfSign.BindPdf(inputPath);

            // Remove all digital signatures; fields remain unchanged.
            pdfSign.RemoveSignatures();

            // Persist the modified PDF.
            pdfSign.Save(outputPath);
        }

        Console.WriteLine($"All signatures removed. Output saved to '{outputPath}'.");
    }
}