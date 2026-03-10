using System;
using System.Collections.Generic;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Input PDF that contains a digital signature
        const string inputPath  = "signed_input.pdf";
        // Output PDF where the signature is removed but the signature field remains
        const string outputPath = "signature_removed.pdf";

        // Ensure the input file exists
        if (!System.IO.File.Exists(inputPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        try
        {
            // Initialize the PdfFileSignature facade
            PdfFileSignature pdfSignature = new PdfFileSignature();

            // Bind the existing PDF document
            pdfSignature.BindPdf(inputPath);

            // Retrieve all existing signature names
            IList<SignatureName> signatureNames = pdfSignature.GetSignatureNames();

            // Remove each signature while preserving its field (removeField = false)
            foreach (SignatureName sigName in signatureNames)
            {
                pdfSignature.RemoveSignature(sigName, false);
            }

            // Save the modified PDF
            pdfSignature.Save(outputPath);

            Console.WriteLine($"Signature(s) removed. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}