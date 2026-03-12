using System;
using System.IO;
using Aspose.Pdf;                 // Core PDF classes (Document, PclLoadOptions, etc.)
using Aspose.Pdf.Facades;        // Facade classes (PdfFileStamp, Stamp)

class Program
{
    static void Main()
    {
        // Paths – adjust as needed
        const string pclPath      = "source.pcl";      // PCL file to be used as a stamp
        const string targetPdf    = "target.pdf";      // PDF that will receive the stamp
        const string outputPdf    = "stamped_output.pdf";

        // Verify input files exist
        if (!File.Exists(pclPath))
        {
            Console.Error.WriteLine($"PCL source not found: {pclPath}");
            return;
        }
        if (!File.Exists(targetPdf))
        {
            Console.Error.WriteLine($"Target PDF not found: {targetPdf}");
            return;
        }

        try
        {
            // ------------------------------------------------------------
            // 1. Load the PCL file into a Document (PDF in memory)
            // ------------------------------------------------------------
            using (var pclDoc = new Document(pclPath, new PclLoadOptions()))
            {
                // Save the converted PDF into a memory stream (no file on disk)
                using (var sourcePdfStream = new MemoryStream())
                {
                    pclDoc.Save(sourcePdfStream);          // Saves as PDF (default format)
                    sourcePdfStream.Position = 0;          // Reset for reading

                    // ------------------------------------------------------------
                    // 2. Prepare the PdfFileStamp facade for the target PDF
                    // ------------------------------------------------------------
                    var fileStamp = new PdfFileStamp();    // Default constructor
                    fileStamp.BindPdf(targetPdf);           // Load the PDF to be stamped

                    // ------------------------------------------------------------
                    // 3. Create a Stamp object that uses the first page of the
                    //    in‑memory PDF (converted from PCL) as its content
                    // ------------------------------------------------------------
                    Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
                    stamp.BindPdf(sourcePdfStream, 1);      // Use page 1 of the source PDF

                    // Optional visual settings for the stamp
                    stamp.IsBackground = true;             // Place behind existing content
                    stamp.Opacity      = 0.6f;             // 60 % opacity
                    stamp.SetOrigin(100, 200);             // Position (X,Y) from lower‑left corner
                    stamp.SetImageSize(250, 150);          // Scale the stamp page

                    // ------------------------------------------------------------
                    // 4. Add the stamp to the document and save the result
                    // ------------------------------------------------------------
                    fileStamp.AddStamp(stamp);
                    fileStamp.Save(outputPdf);              // Write the stamped PDF
                    fileStamp.Close();                     // Release resources
                }
            }

            Console.WriteLine($"Stamp applied successfully. Output saved to '{outputPdf}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
