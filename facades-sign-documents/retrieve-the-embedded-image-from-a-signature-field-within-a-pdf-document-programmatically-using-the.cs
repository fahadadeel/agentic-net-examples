using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string pdfPath      = "signed_document.pdf";   // input PDF containing a signature field
        const string signatureName = "Signature1";           // name of the signature field to extract the image from
        const string outputImage   = "signature_image.jpg"; // output image file

        if (!File.Exists(pdfPath))
        {
            Console.Error.WriteLine($"PDF file not found: {pdfPath}");
            return;
        }

        // PdfFileSignature implements IDisposable, so use a using block for deterministic disposal
        using (PdfFileSignature pdfSignature = new PdfFileSignature())
        {
            // Bind the PDF file to the facade
            pdfSignature.BindPdf(pdfPath);

            // Extract the image stream for the specified signature field
            Stream imageStream = pdfSignature.ExtractImage(signatureName);

            if (imageStream == null)
            {
                Console.WriteLine($"No image found in signature field '{signatureName}'.");
                return;
            }

            // Save the extracted image to a file
            using (FileStream fileOut = new FileStream(outputImage, FileMode.Create, FileAccess.Write))
            {
                imageStream.CopyTo(fileOut);
            }

            Console.WriteLine($"Signature image extracted to '{outputImage}'.");
        }
    }
}