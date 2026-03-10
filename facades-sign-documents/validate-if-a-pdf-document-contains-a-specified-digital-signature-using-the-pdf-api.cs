using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Pdf.Facades; // Provides PdfFileSignature and SignatureName classes

class Program
{
    static void Main()
    {
        // Path to the PDF file to be examined
        const string pdfPath = "sample.pdf";
        // Name of the digital signature to look for
        const string signatureName = "Signature1";

        if (!File.Exists(pdfPath))
        {
            Console.Error.WriteLine($"File not found: {pdfPath}");
            return;
        }

        // Initialize the PdfFileSignature facade and bind the PDF document
        using (PdfFileSignature pdfSign = new PdfFileSignature())
        {
            pdfSign.BindPdf(pdfPath);

            // Determine whether the PDF contains any digital signature at all
            bool anySignature = pdfSign.ContainsSignature();
            Console.WriteLine($"Contains any signature: {anySignature}");

            // Retrieve the list of all non‑empty signature names (as strings)
            IList<SignatureName> signatureInfo = pdfSign.GetSignatureNames(true);
            List<string> signatureNames = signatureInfo
                                            .Where(sn => !string.IsNullOrEmpty(sn.Name))
                                            .Select(sn => sn.Name)
                                            .ToList();

            // Check if the specified signature name is present
            bool hasSpecified = signatureNames.Contains(signatureName);
            Console.WriteLine($"Signature \"{signatureName}\" present: {hasSpecified}");
        }
    }
}
