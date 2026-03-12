using System;
using System.IO;
using System.Drawing; // Required for System.Drawing.Color used by FormattedText
using Aspose.Pdf;          // Core PDF API
using Aspose.Pdf.Facades; // Facades API for stamping

class Program
{
    static void Main()
    {
        const string epubPath = "input.epub";        // Source EPUB file
        const string outputPdfPath = "watermarked.pdf"; // Destination PDF file

        // Verify source file exists
        if (!File.Exists(epubPath))
        {
            Console.Error.WriteLine($"Source file not found: {epubPath}");
            return;
        }

        // Load the EPUB into a PDF document using the proper load options
        using (Document pdfDoc = new Document(epubPath, new EpubLoadOptions()))
        {
            // Prepare multi‑line watermark text.
            string watermarkText = "CONFIDENTIAL\nDo Not Distribute\n© 2026 Company";

            // FormattedText lives in the Facades namespace; fully qualify to avoid ambiguity.
            Aspose.Pdf.Facades.FormattedText ft = new Aspose.Pdf.Facades.FormattedText(
                watermarkText,                     // Text (supports \n for new lines)
                System.Drawing.Color.Red,         // Text color (System.Drawing.Color)
                "Helvetica",                     // Font name
                Aspose.Pdf.Facades.EncodingType.Winansi, // Text encoding
                false,                            // Do not embed the font (set true if needed)
                48);                              // Font size

            // Stamp also exists in both core and facades namespaces – use the facades version.
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(ft);               // Attach the formatted text as the stamp content
            stamp.IsBackground = true;        // Render as background (behind page content)
            stamp.Opacity = 0.3f;             // Semi‑transparent watermark
            stamp.Rotation = 45;              // Optional rotation for visual effect

            // Initialize the PdfFileStamp facade with the loaded document.
            Aspose.Pdf.Facades.PdfFileStamp fileStamp = new Aspose.Pdf.Facades.PdfFileStamp();
            fileStamp.BindPdf(pdfDoc);        // Bind the in‑memory PDF document

            // Add the configured stamp to all pages.
            fileStamp.AddStamp(stamp);

            // Save the resulting PDF.
            fileStamp.Save(outputPdfPath);
            fileStamp.Close();                // Close the facade (writes changes)

            Console.WriteLine($"Watermarked PDF saved to '{outputPdfPath}'.");
        }
    }
}
