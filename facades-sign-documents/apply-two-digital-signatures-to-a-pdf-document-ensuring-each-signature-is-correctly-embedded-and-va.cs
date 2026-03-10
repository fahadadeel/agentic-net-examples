using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System.Drawing; // needed for System.Drawing.Rectangle

class Program
{
    static void Main()
    {
        const string inputPdf = "input.pdf";
        const string outputPdf = "signed_output.pdf";
        const string certPath = "certificate.pfx";
        const string certPassword = "password";
        const string appearanceImage = "signature_appearance.jpg";

        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"Input file not found: {inputPdf}");
            return;
        }

        if (!File.Exists(certPath))
        {
            Console.Error.WriteLine($"Certificate file not found: {certPath}");
            return;
        }

        // Initialize the PdfFileSignature facade and bind the source PDF
        using (PdfFileSignature pdfSign = new PdfFileSignature())
        {
            pdfSign.BindPdf(inputPdf);

            // Optional visual appearance for the signatures
            pdfSign.SignatureAppearance = appearanceImage;

            // Set the certificate used for signing
            pdfSign.SetCertificate(certPath, certPassword);

            // First signature on page 1
            System.Drawing.Rectangle rect1 = new System.Drawing.Rectangle(100, 100, 200, 50);
            pdfSign.Sign(
                page: 1,
                SigReason: "First signature",
                SigContact: "alice@example.com",
                SigLocation: "New York",
                visible: true,
                annotRect: rect1);

            // Second signature on page 2
            System.Drawing.Rectangle rect2 = new System.Drawing.Rectangle(100, 200, 200, 50);
            pdfSign.Sign(
                page: 2,
                SigReason: "Second signature",
                SigContact: "bob@example.com",
                SigLocation: "London",
                visible: true,
                annotRect: rect2);

            // Verify each signature and output the result
            var signatureNames = pdfSign.GetSignatureNames(true);
            foreach (var name in signatureNames)
            {
                bool isValid = pdfSign.VerifySignature(name);
                Console.WriteLine($"Signature '{name}' validation result: {isValid}");
            }

            // Save the signed PDF
            pdfSign.Save(outputPdf);
        }

        Console.WriteLine($"Signed PDF saved to '{outputPdf}'.");
    }
}