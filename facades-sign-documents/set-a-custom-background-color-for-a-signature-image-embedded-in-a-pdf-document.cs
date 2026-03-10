using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;

class Program
{
    static void Main()
    {
        // Input PDF, output PDF and signature image paths
        const string inputPdf   = "input.pdf";
        const string outputPdf  = "signed_output.pdf";
        const string appearance = "signature_image.jpg";

        // Certificate file (PFX) and password
        const string certPath   = "certificate.pfx";
        const string certPass   = "password";

        // Ensure input files exist
        if (!File.Exists(inputPdf) || !File.Exists(appearance) || !File.Exists(certPath))
        {
            Console.Error.WriteLine("One or more required files are missing.");
            return;
        }

        // Create the PdfFileSignature facade
        PdfFileSignature pdfSign = new PdfFileSignature();

        // Load the PDF document to be signed
        pdfSign.BindPdf(inputPdf);

        // Set the visual appearance of the signature (image file)
        pdfSign.SignatureAppearance = appearance;

        // Create a PKCS#1 signature object and set its properties
        PKCS1 signature = new PKCS1(certPath, certPass)
        {
            Reason      = "Approved",
            ContactInfo = "john.doe@example.com",
            Location    = "New York"
        };

        // Create a custom appearance and set a background color
        SignatureCustomAppearance customAppearance = new SignatureCustomAppearance
        {
            // Use Aspose.Pdf.Color for cross‑platform compatibility
            BackgroundColor = Aspose.Pdf.Color.Yellow
        };

        // Assign the custom appearance to the signature
        signature.CustomAppearance = customAppearance;

        // Define the rectangle where the signature will be placed.
        // Use the fully qualified System.Drawing.Rectangle to avoid ambiguity.
        System.Drawing.Rectangle rect = new System.Drawing.Rectangle(100, 100, 200, 200);

        // Sign the document on page 1, make the signature visible, and use the rectangle.
        pdfSign.Sign(page: 1, visible: true, annotRect: rect, sig: signature);

        // Save the signed PDF
        pdfSign.Save(outputPdf);

        Console.WriteLine($"Signed PDF saved to '{outputPdf}'.");
    }
}
