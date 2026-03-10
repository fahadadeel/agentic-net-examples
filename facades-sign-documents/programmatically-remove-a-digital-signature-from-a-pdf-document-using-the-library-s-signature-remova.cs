using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPath  = "signed_input.pdf";
        const string outputPath = "signature_removed.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        try
        {
            // Create the facade, bind the PDF, remove all signatures, and save.
            PdfFileSignature pdfSignature = new PdfFileSignature();
            pdfSignature.BindPdf(inputPath);
            pdfSignature.RemoveSignatures();          // Removes every digital signature.
            pdfSignature.Save(outputPath);
            pdfSignature.Close();                     // Release resources.

            Console.WriteLine($"All signatures removed. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}