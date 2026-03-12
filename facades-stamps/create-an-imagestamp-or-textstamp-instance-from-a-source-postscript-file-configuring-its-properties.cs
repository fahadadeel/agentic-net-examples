using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string targetPdfPath = "target.pdf";          // PDF to be stamped
        const string sourcePsPath  = "stamp_source.ps";    // Source PostScript file
        const string outputPdfPath = "stamped_output.pdf"; // Result PDF

        // Verify input files exist
        if (!File.Exists(targetPdfPath))
        {
            Console.Error.WriteLine($"Target PDF not found: {targetPdfPath}");
            return;
        }
        if (!File.Exists(sourcePsPath))
        {
            Console.Error.WriteLine($"Source PostScript not found: {sourcePsPath}");
            return;
        }

        // Convert the PostScript file to a temporary PDF (required for stamping)
        string tempPdfPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");
        try
        {
            using (Document psDoc = new Document(sourcePsPath, new PsLoadOptions()))
            {
                psDoc.Save(tempPdfPath); // Save as PDF; this PDF will be used as the stamp source
            }

            // Initialize the PdfFileStamp facade for the target PDF
            using (PdfFileStamp fileStamp = new PdfFileStamp())
            {
                // Bind the target PDF (input)
                fileStamp.BindPdf(targetPdfPath);

                // Create a stamp that uses the first page of the converted PDF (from PS) as its content
                Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
                stamp.BindPdf(tempPdfPath, 1);          // Bind the first page of the temp PDF as stamp
                stamp.IsBackground = true;              // Place stamp behind page content
                stamp.Opacity = 0.6f;                    // Semi‑transparent
                stamp.SetOrigin(100, 200);               // Position (X, Y) from lower‑left corner
                stamp.SetImageSize(150, 100);            // Desired size of the stamp

                // Add the stamp to the document and save the result
                fileStamp.AddStamp(stamp);
                fileStamp.Save(outputPdfPath);
            }

            Console.WriteLine($"Stamp applied successfully. Output saved to '{outputPdfPath}'.");
        }
        finally
        {
            // Clean up the temporary PDF if it exists
            if (File.Exists(tempPdfPath))
            {
                try { File.Delete(tempPdfPath); } catch { /* ignore cleanup errors */ }
            }
        }
    }
}