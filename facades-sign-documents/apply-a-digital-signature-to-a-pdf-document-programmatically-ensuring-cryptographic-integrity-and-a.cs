using System;
using System.IO;
using Aspose.Pdf.Facades;          // PdfFileSignature facade
using Aspose.Pdf.Forms;           // Signature types (PKCS1, PKCS7, etc.)

class Program
{
    static void Main()
    {
        // Input PDF to be signed, output PDF, certificate (PFX) and optional appearance image.
        const string inputPdf   = "input.pdf";
        const string outputPdf  = "signed_output.pdf";
        const string certPath   = "certificate.pfx";
        const string certPass   = "password";
        const string appearance = "signature_appearance.jpg";

        // Verify that required files exist.
        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdf}");
            return;
        }
        if (!File.Exists(certPath))
        {
            Console.Error.WriteLine($"Certificate file not found: {certPath}");
            return;
        }

        // Create the PdfFileSignature facade.
        using (PdfFileSignature pdfSign = new PdfFileSignature())
        {
            // Bind the existing PDF file.
            pdfSign.BindPdf(inputPdf);

            // Optional: set a visual appearance for the signature.
            if (File.Exists(appearance))
                pdfSign.SignatureAppearance = appearance;

            // Provide the signing certificate and its password.
            pdfSign.SetCertificate(certPath, certPass);

            // Define the rectangle where the signature will be placed.
            // System.Drawing.Rectangle is required by the Sign method.
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(100, 100, 200, 100);

            // Sign the document.
            // Parameters: page number (1‑based), reason, contact, location, visibility, rectangle.
            pdfSign.Sign(
                page: 1,
                SigReason: "Document approved",
                SigContact: "john.doe@example.com",
                SigLocation: "New York",
                visible: true,
                annotRect: rect);

            // Save the signed PDF.
            pdfSign.Save(outputPdf);
        }

        Console.WriteLine($"Signed PDF saved to '{outputPdf}'.");
    }
}