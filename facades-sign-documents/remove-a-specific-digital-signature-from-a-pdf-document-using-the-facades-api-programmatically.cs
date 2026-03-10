using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Input PDF that contains digital signatures
        const string inputPdf = "signed_document.pdf";

        // Name of the signature to be removed (as stored in the PDF)
        const string signatureName = "Signature1";

        // Output PDF after the signature has been removed
        const string outputPdf = "signed_document_without_signature.pdf";

        // Verify that the source file exists
        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"Input file not found: {inputPdf}");
            return;
        }

        // Use the PdfFileSignature facade to manipulate signatures.
        // The facade implements IDisposable, so wrap it in a using block.
        using (PdfFileSignature pdfSignature = new PdfFileSignature())
        {
            // Bind the existing PDF file to the facade.
            pdfSignature.BindPdf(inputPdf);

            // Optional: check whether the PDF actually contains signatures.
            if (!pdfSignature.ContainsSignature())
            {
                Console.WriteLine("The document does not contain any digital signatures.");
            }
            else
            {
                // Remove the specific signature by its name.
                // The second overload (bool removeField) can be used if you also want to delete the empty signature field.
                // Here we remove only the signature, leaving the field intact.
                pdfSignature.RemoveSignature(signatureName, false);
                Console.WriteLine($"Signature '{signatureName}' removed.");
            }

            // Save the modified PDF to a new file.
            pdfSignature.Save(outputPdf);
        }

        Console.WriteLine($"Result saved to: {outputPdf}");
    }
}