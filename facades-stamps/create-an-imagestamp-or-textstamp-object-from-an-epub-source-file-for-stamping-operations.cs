using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPdfPath = "input.pdf";   // PDF to be stamped
        const string epubPath     = "source.epub"; // EPUB source for the stamp
        const string outputPdfPath = "output.pdf"; // Resulting PDF

        if (!File.Exists(inputPdfPath) || !File.Exists(epubPath))
        {
            Console.Error.WriteLine("Required files not found.");
            return;
        }

        // Load the target PDF (the document that will receive the stamp)
        using (Document targetDoc = new Document(inputPdfPath))
        {
            // Load the EPUB file and convert it to PDF in memory
            using (Document epubDoc = new Document(epubPath, new EpubLoadOptions()))
            {
                using (MemoryStream epubPdfStream = new MemoryStream())
                {
                    // Save the EPUB as PDF into the memory stream
                    epubDoc.Save(epubPdfStream);
                    epubPdfStream.Position = 0; // reset stream position for reading

                    // Create a stamp using the first page of the converted EPUB PDF
                    Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
                    // Bind the PDF stream (page 1) as the stamp content
                    stamp.BindPdf(epubPdfStream, 1);
                    stamp.IsBackground = true;          // place stamp behind page content
                    stamp.Opacity = 0.5f;               // semi‑transparent
                    stamp.SetOrigin(100, 500);          // position on the page
                    stamp.SetImageSize(200, 300);       // size of the stamp

                    // Apply the stamp to the target PDF using the PdfFileStamp facade
                    using (PdfFileStamp fileStamp = new PdfFileStamp())
                    {
                        // Bind the target PDF document to the facade
                        fileStamp.BindPdf(targetDoc);
                        // Add the prepared stamp
                        fileStamp.AddStamp(stamp);
                        // Save the stamped PDF
                        fileStamp.Save(outputPdfPath);
                    }
                }
            }
        }

        Console.WriteLine($"Stamped PDF saved to '{outputPdfPath}'.");
    }
}
