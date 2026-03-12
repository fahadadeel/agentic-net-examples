using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Drawing;

class Program
{
    static void Main()
    {
        // Input PDF to be stamped
        const string inputPdfPath = "input.pdf";
        // Source CGM file that will be used as the stamp content
        const string cgmPath = "stamp.cgm";
        // Output PDF with the applied stamp
        const string outputPdfPath = "output.pdf";

        // Verify that required files exist
        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdfPath}");
            return;
        }
        if (!File.Exists(cgmPath))
        {
            Console.Error.WriteLine($"Source CGM not found: {cgmPath}");
            return;
        }

        // Load the target PDF document
        using (Document targetDoc = new Document(inputPdfPath))
        // Load the CGM file as a PDF document (CGM is input‑only)
        using (Document cgmDoc = new Document(cgmPath, new CgmLoadOptions()))
        {
            // Create a page‑stamp using the first page of the CGM document
            PdfPageStamp stamp = new PdfPageStamp(cgmDoc.Pages[1]);

            // Center the stamp horizontally and vertically on each page
            stamp.HorizontalAlignment = HorizontalAlignment.Center;
            stamp.VerticalAlignment   = VerticalAlignment.Center;

            // Apply the stamp to every page of the target PDF
            foreach (Page page in targetDoc.Pages)
            {
                page.AddStamp(stamp);
            }

            // Save the modified PDF
            targetDoc.Save(outputPdfPath);
        }

        Console.WriteLine($"Stamped PDF saved to '{outputPdfPath}'.");
    }
}