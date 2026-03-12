using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Input PDF to be stamped, output PDF, and MHT source file
        const string inputPdfPath   = "input.pdf";
        const string outputPdfPath  = "output.pdf";
        const string mhtSourcePath  = "source.mht";

        // Desired rotation angle in degrees (arbitrary angle allowed)
        const float rotationAngle = 45f;

        // Verify that required files exist
        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdfPath}");
            return;
        }
        if (!File.Exists(mhtSourcePath))
        {
            Console.Error.WriteLine($"MHT source not found: {mhtSourcePath}");
            return;
        }

        // -----------------------------------------------------------------
        // Convert the MHT file to a temporary PDF (required because Stamp can
        // bind only PDF pages). The temporary file is stored in the OS temp
        // folder and deleted after stamping.
        // -----------------------------------------------------------------
        string tempPdfPath = Path.Combine(Path.GetTempPath(), "mht_temp.pdf");
        using (Document mhtDoc = new Document(mhtSourcePath, new MhtLoadOptions()))
        {
            mhtDoc.Save(tempPdfPath);
        }

        // -----------------------------------------------------------------
        // Initialize the PdfFileStamp facade and bind the target PDF.
        // -----------------------------------------------------------------
        PdfFileStamp fileStamp = new PdfFileStamp();
        fileStamp.BindPdf(inputPdfPath);

        // -----------------------------------------------------------------
        // Create a stamp that uses the first page of the temporary PDF.
        // Set the rotation angle and optionally the origin position.
        // -----------------------------------------------------------------
        Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
        stamp.BindPdf(tempPdfPath, 1);          // use page 1 of the temp PDF as stamp content
        stamp.Rotation = rotationAngle;         // apply the desired rotation
        stamp.SetOrigin(100f, 100f);            // position of the stamp on each page (optional)

        // Add the configured stamp to all pages of the target document
        fileStamp.AddStamp(stamp);

        // Save the stamped PDF and close the facade (no using block per rules)
        fileStamp.Save(outputPdfPath);
        fileStamp.Close();

        // Clean up the temporary PDF file
        try { File.Delete(tempPdfPath); } catch { }

        Console.WriteLine($"Stamped PDF saved to '{outputPdfPath}'.");
    }
}