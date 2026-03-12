using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string cgmPath       = "input.cgm";      // source CGM file
        const string outputPdfPath = "output.pdf";     // result PDF
        const float  rotationDeg   = 45f;              // desired rotation in degrees

        if (!File.Exists(cgmPath))
        {
            Console.Error.WriteLine($"File not found: {cgmPath}");
            return;
        }

        // Load the CGM file as a PDF document using the proper load options.
        using (Document doc = new Document(cgmPath, new CgmLoadOptions()))
        {
            // Create a stamp (facade version) and bind a simple text logo.
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(new FormattedText("STAMP"));

            // Apply the rotation angle obtained from the CGM coordinates.
            stamp.Rotation = rotationDeg;

            // Position the stamp on the page (example coordinates).
            stamp.SetOrigin(100, 100);

            // Apply the stamp to the loaded document.
            PdfFileStamp fileStamp = new PdfFileStamp();
            fileStamp.BindPdf(doc);          // bind the in‑memory PDF
            fileStamp.AddStamp(stamp);       // add the configured stamp
            fileStamp.Close();               // finalize stamping

            // Save the stamped PDF.
            doc.Save(outputPdfPath);
        }

        Console.WriteLine($"Stamped PDF saved to '{outputPdfPath}'.");
    }
}