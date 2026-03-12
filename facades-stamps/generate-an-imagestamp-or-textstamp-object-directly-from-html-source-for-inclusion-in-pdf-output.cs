using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Paths for source HTML, the PDF to be stamped, and the final output PDF.
        const string htmlPath   = "source.html";
        const string inputPdf   = "document.pdf";
        const string outputPdf  = "document_with_stamp.pdf";

        // Verify that required files exist.
        if (!File.Exists(htmlPath))
        {
            Console.Error.WriteLine($"HTML source not found: {htmlPath}");
            return;
        }
        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdf}");
            return;
        }

        try
        {
            // -----------------------------------------------------------------
            // 1. Load the HTML file into a PDF Document (in memory).
            // -----------------------------------------------------------------
            using (MemoryStream htmlPdfStream = new MemoryStream())
            {
                // Load HTML with explicit HtmlLoadOptions (required for HTML input).
                using (Document htmlDoc = new Document(htmlPath, new HtmlLoadOptions()))
                {
                    // Save the generated PDF into a memory stream.
                    htmlDoc.Save(htmlPdfStream);
                }

                // Reset stream position for subsequent reading.
                htmlPdfStream.Position = 0;

                // -----------------------------------------------------------------
                // 2. Prepare the PdfFileStamp facade for the target PDF.
                // -----------------------------------------------------------------
                using (PdfFileStamp fileStamp = new PdfFileStamp())
                {
                    // Bind the source PDF file (the document that will receive the stamp).
                    fileStamp.BindPdf(inputPdf);

                    // -----------------------------------------------------------------
                    // 3. Create a Stamp object and bind the HTML‑derived PDF page.
                    // -----------------------------------------------------------------
                    Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

                    // Bind the first page of the in‑memory PDF (generated from HTML) as the stamp.
                    // The page number is 1‑based.
                    stamp.BindPdf(htmlPdfStream, 1);

                    // Configure stamp appearance (optional).
                    stamp.IsBackground = true;   // place stamp behind page content
                    stamp.Opacity      = 0.6f;   // semi‑transparent
                    stamp.SetOrigin(100, 500);   // position (X, Y) in points

                    // -----------------------------------------------------------------
                    // 4. Add the stamp to the document and finalize.
                    // -----------------------------------------------------------------
                    fileStamp.AddStamp(stamp);

                    // Save the result to the output file.
                    fileStamp.Save(outputPdf);
                }
            }

            Console.WriteLine($"Stamp added successfully. Output saved to '{outputPdf}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
