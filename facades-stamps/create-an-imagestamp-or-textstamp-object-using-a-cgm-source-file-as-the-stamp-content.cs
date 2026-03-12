using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPdfPath   = "input.pdf";      // PDF to be stamped
        const string cgmSourcePath  = "stamp.cgm";      // CGM file used as stamp content
        const string outputPdfPath  = "output.pdf";     // Resulting PDF

        // Verify files exist
        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdfPath}");
            return;
        }
        if (!File.Exists(cgmSourcePath))
        {
            Console.Error.WriteLine($"CGM source not found: {cgmSourcePath}");
            return;
        }

        // Load the CGM file and convert it to a PDF stored in a memory stream.
        // CGM is input‑only; we first render it to PDF, then use that PDF page as a stamp.
        using (var cgmDoc = new Document(cgmSourcePath, new CgmLoadOptions()))
        using (var cgmPdfStream = new MemoryStream())
        {
            // Save the rendered CGM as PDF into the stream.
            cgmDoc.Save(cgmPdfStream);
            cgmPdfStream.Position = 0; // Reset stream for reading.

            // Prepare the facade that will apply the stamp to the target PDF.
            using (var pdfStampFacade = new PdfFileStamp())
            {
                // Bind the target PDF file.
                pdfStampFacade.BindPdf(inputPdfPath);

                // Create a stamp object and bind the first page of the CGM‑converted PDF as its content.
                Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
                stamp.BindPdf(cgmPdfStream, 1); // Use page 1 of the CGM‑PDF as stamp.

                // Optional: configure stamp appearance.
                stamp.IsBackground = false;          // Stamp will appear on top of page content.
                stamp.Opacity = 0.9f;                // Slightly transparent.
                stamp.SetOrigin(100f, 500f);         // Position (X, Y) from bottom‑left corner.
                stamp.SetImageSize(200f, 150f);      // Desired width and height of the stamp.

                // Add the configured stamp to the document.
                pdfStampFacade.AddStamp(stamp);

                // Save the stamped document.
                pdfStampFacade.Save(outputPdfPath);
                pdfStampFacade.Close();
            }
        }

        Console.WriteLine($"Stamped PDF saved to '{outputPdfPath}'.");
    }
}