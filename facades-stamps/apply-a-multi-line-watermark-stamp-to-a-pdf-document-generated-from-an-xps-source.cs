using System;
using System.IO;
using Aspose.Pdf;                     // Core PDF API
using Aspose.Pdf.Facades;            // Facades API (PdfFileStamp, Stamp, FormattedText, EncodingType)

class Program
{
    static void Main()
    {
        const string xpsPath = "input.xps";                 // Source XPS file
        const string intermediatePdfPath = "intermediate.pdf"; // Temporary PDF after conversion
        const string outputPdfPath = "watermarked.pdf";      // Final PDF with watermark

        // Verify source file exists
        if (!File.Exists(xpsPath))
        {
            Console.Error.WriteLine($"XPS file not found: {xpsPath}");
            return;
        }

        // ------------------------------------------------------------
        // Step 1: Convert XPS to PDF using the core Document API.
        // XpsLoadOptions is required for loading XPS files.
        // ------------------------------------------------------------
        using (Document pdfDoc = new Document(xpsPath, new XpsLoadOptions()))
        {
            // Save as PDF (Document.Save without SaveOptions writes PDF)
            pdfDoc.Save(intermediatePdfPath);
        }

        // ------------------------------------------------------------
        // Step 2: Create a multi‑line watermark stamp.
        // FormattedText constructor requires System.Drawing.Color.
        // ------------------------------------------------------------
        FormattedText watermarkText = new FormattedText(
            "Confidential\nDo Not Distribute\nCompany XYZ", // Multi‑line text (\n separates lines)
            System.Drawing.Color.Red,                      // Text color (System.Drawing.Color is required here)
            "Helvetica",                                   // Font name
            EncodingType.Winansi,                           // Text encoding
            false,                                          // Embedded flag
            48);                                            // Font size

        // Create a Stamp object and bind the formatted text.
        Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
        stamp.BindLogo(watermarkText);
        stamp.SetOrigin(100, 400);   // Position of the watermark on the page (X, Y)
        stamp.Opacity = 0.5f;        // Semi‑transparent
        stamp.IsBackground = true;  // Render behind page content

        // ------------------------------------------------------------
        // Step 3: Apply the stamp to the PDF using PdfFileStamp.
        // PdfFileStamp does NOT implement IDisposable; do not wrap in using.
        // ------------------------------------------------------------
        PdfFileStamp fileStamp = new PdfFileStamp();
        try
        {
            fileStamp.BindPdf(intermediatePdfPath); // Load the PDF to be stamped
            fileStamp.AddStamp(stamp);              // Add the watermark stamp to all pages
            fileStamp.Save(outputPdfPath);          // Save the result
        }
        finally
        {
            // Close releases resources; required even though not IDisposable.
            fileStamp.Close();
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdfPath}'.");
    }
}
