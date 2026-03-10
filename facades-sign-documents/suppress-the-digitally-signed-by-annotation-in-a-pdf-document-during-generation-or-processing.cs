using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Paths to the source PDF and the output PDF
        const string inputPath  = "input.pdf";
        const string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Create the PdfFileSignature facade, bind the PDF, remove all signatures,
        // and save the result. This suppresses the “Digitally signed by” annotation.
        using (PdfFileSignature pdfSignature = new PdfFileSignature())
        {
            // Load the PDF document into the facade
            pdfSignature.BindPdf(inputPath);

            // Remove all existing digital signatures (including the visible annotation)
            pdfSignature.RemoveSignatures();

            // Save the modified PDF
            pdfSignature.Save(outputPath);
        }

        Console.WriteLine($"Signature annotation suppressed. Output saved to '{outputPath}'.");
    }
}