using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPath = "signed_input.pdf";
        const string outputPath = "signatures_removed.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Initialize the PdfFileSignature facade
        using (PdfFileSignature pdfSignature = new PdfFileSignature())
        {
            // Load the PDF document into the facade
            pdfSignature.BindPdf(inputPath);

            // Remove all embedded signatures while keeping other content intact
            pdfSignature.RemoveSignatures();

            // Save the resulting PDF
            pdfSignature.Save(outputPath);
        }

        Console.WriteLine($"All signatures removed. Output saved to '{outputPath}'.");
    }
}