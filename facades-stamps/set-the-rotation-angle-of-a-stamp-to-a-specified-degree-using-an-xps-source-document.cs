using System;
using System.IO;
using Aspose.Pdf;                     // Core PDF API (Document, XpsLoadOptions)
using Aspose.Pdf.Facades;            // Facade API (PdfFileStamp, Stamp, FormattedText)

class Program
{
    static void Main()
    {
        const string xpsInputPath   = "input.xps";      // XPS source document
        const string pdfOutputPath  = "output.pdf";     // Resulting PDF with rotated stamp
        const float  stampRotation  = 45f;              // Desired rotation angle in degrees

        if (!File.Exists(xpsInputPath))
        {
            Console.Error.WriteLine($"File not found: {xpsInputPath}");
            return;
        }

        // Load the XPS file into a PDF Document (core API)
        using (Document pdfDoc = new Document(xpsInputPath, new XpsLoadOptions()))
        {
            // Create a text stamp using the Facade API
            // FormattedText constructor requires System.Drawing.Color for the text color
            FormattedText ft = new FormattedText(
                "Sample Stamp",                     // Text to display
                System.Drawing.Color.Red,           // Text color
                "Helvetica",                        // Font name
                EncodingType.Winansi,               // Encoding
                false,                              // IsEmbedded
                36);                                // Font size

            // Fully qualified Stamp from Aspose.Pdf.Facades to avoid ambiguity
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(ft);                    // Bind the formatted text to the stamp
            stamp.Rotation = stampRotation;        // Set rotation angle (float, degrees)

            // Initialize PdfFileStamp facade and bind the PDF document
            PdfFileStamp fileStamp = new PdfFileStamp();
            fileStamp.BindPdf(pdfDoc);             // Bind the in‑memory PDF

            // Add the rotated stamp to the document
            fileStamp.AddStamp(stamp);

            // Save the result
            fileStamp.Save(pdfOutputPath);
            fileStamp.Close();                     // Close the facade (releases resources)
        }

        Console.WriteLine($"PDF with rotated stamp saved to '{pdfOutputPath}'.");
    }
}