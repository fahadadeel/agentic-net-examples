using System;
using System.IO;
using System.Drawing;
using System.Globalization;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Forms;

class Program
{
    static void Main()
    {
        // Input and output PDF files
        const string inputPdf  = "input.pdf";
        const string outputPdf = "signed_output.pdf";

        // Certificate (PKCS#12) file and password
        const string certPath = "certificate.pfx";
        const string certPassword = "password";

        // Desired localization (e.g., French)
        CultureInfo signatureCulture = new CultureInfo("fr-FR");

        // Custom labels for the signature appearance
        const string digitalSignedLabel = "Signé numériquement par";
        const string reasonLabel        = "Raison";
        const string locationLabel      = "Lieu";
        const string dateSignedAtLabel  = "Date";

        // Verify that the input files exist
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

        // Bind the PDF to the signature facade
        PdfFileSignature pdfSign = new PdfFileSignature();
        pdfSign.BindPdf(inputPdf);

        // Set the certificate for signing
        pdfSign.SetCertificate(certPath, certPassword);

        // Optional: set a visual appearance image for the signature
        // pdfSign.SignatureAppearance = "signature_appearance.jpg";

        // Create a PKCS#7 signature object
        PKCS7 pkcs7 = new PKCS7(certPath, certPassword)
        {
            Reason   = "Document approuvé",
            ContactInfo = "contact@example.com",
            Location = "Paris, France",
            // Date defaults to current time; can be set explicitly if needed
        };

        // Configure custom appearance with localized labels
        SignatureCustomAppearance customAppearance = new SignatureCustomAppearance
        {
            DigitalSignedLabel = digitalSignedLabel,
            ReasonLabel        = reasonLabel,
            LocationLabel      = locationLabel,
            DateSignedAtLabel  = dateSignedAtLabel,
            Culture            = signatureCulture,
            // Optional styling
            FontFamilyName = "Arial",
            FontSize       = 10,
            ForegroundColor = Aspose.Pdf.Color.Blue,
            BackgroundColor = Aspose.Pdf.Color.Transparent
        };
        pkcs7.CustomAppearance = customAppearance;

        // Define the signature rectangle (position and size) on page 1
        System.Drawing.Rectangle signatureRect = new System.Drawing.Rectangle(100, 100, 200, 100);

        // Apply the signature (visible = true) on the first page
        pdfSign.Sign(page: 1, visible: true, annotRect: signatureRect, sig: pkcs7);

        // Save the signed PDF
        pdfSign.Save(outputPdf);

        Console.WriteLine($"Signed PDF saved to '{outputPdf}'.");
    }
}