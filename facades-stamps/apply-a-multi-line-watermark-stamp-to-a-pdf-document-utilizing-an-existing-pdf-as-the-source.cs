using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Input PDF that will receive the watermark
        const string sourcePdf = "source.pdf";
        // PDF containing the multi‑line watermark (use its first page as stamp)
        const string stampPdf = "stamp.pdf";
        // Output PDF with the applied watermark
        const string outputPdf = "watermarked.pdf";

        if (!File.Exists(sourcePdf))
        {
            Console.Error.WriteLine($"Source file not found: {sourcePdf}");
            return;
        }
        if (!File.Exists(stampPdf))
        {
            Console.Error.WriteLine($"Stamp file not found: {stampPdf}");
            return;
        }

        // Initialize the PdfFileStamp facade (does NOT implement IDisposable)
        PdfFileStamp fileStamp = new PdfFileStamp();

        // Bind the PDF that will be watermarked
        fileStamp.BindPdf(sourcePdf);

        // Create a stamp based on a page from another PDF
        // Fully qualify to avoid ambiguity with Aspose.Pdf.Stamp
        Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

        // Use the first page of stampPdf as the watermark content
        stamp.BindPdf(stampPdf, 1);

        // Place the stamp behind existing page content
        stamp.IsBackground = true;

        // Make the stamp semi‑transparent
        stamp.Opacity = 0.5f;

        // Optional: position and size the stamp on each page
        stamp.SetOrigin(100, 400);          // X and Y coordinates (bottom‑left origin)
        stamp.SetImageSize(200, 200);       // Width and height

        // Add the configured stamp to all pages of the source PDF
        fileStamp.AddStamp(stamp);

        // Save the resulting PDF
        fileStamp.Save(outputPdf);

        // Close the facade to release internal resources
        fileStamp.Close();

        Console.WriteLine($"Watermarked PDF saved to '{outputPdf}'.");
    }
}
