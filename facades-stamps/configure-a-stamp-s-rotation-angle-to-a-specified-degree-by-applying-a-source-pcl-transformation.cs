using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Input PDF to be stamped, source PCL file, and output PDF path
        const string inputPdfPath = "input.pdf";
        const string sourcePclPath = "stamp.pcl";
        const string outputPdfPath = "output.pdf";

        // Desired rotation angle for the stamp (in degrees)
        const float rotationAngle = 45f;

        // Verify that required files exist
        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdfPath}");
            return;
        }
        if (!File.Exists(sourcePclPath))
        {
            Console.Error.WriteLine($"Source PCL not found: {sourcePclPath}");
            return;
        }

        // Load the PCL file (converted internally to a PDF document)
        using (Document pclDocument = new Document(sourcePclPath, new PclLoadOptions()))
        {
            // Create a Facades Stamp and bind the first page of the PCL‑derived PDF.
            // The BindPdf overload that accepts a Document is not available in the
            // current Aspose.PDF version, therefore we save the in‑memory PDF to a
            // stream and bind from that stream.
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            using (MemoryStream pclStream = new MemoryStream())
            {
                pclDocument.Save(pclStream);
                pclStream.Position = 0; // rewind for reading
                stamp.BindPdf(pclStream, 1); // page numbers are 1‑based
            }

            // Set the rotation angle (degrees)
            stamp.Rotation = rotationAngle;

            // Optional visual settings
            stamp.IsBackground = false; // stamp appears on top of page content
            stamp.Opacity = 1.0f;        // fully opaque

            // Apply the stamp to every page of the target PDF
            using (PdfFileStamp pdfFileStamp = new PdfFileStamp())
            {
                pdfFileStamp.BindPdf(inputPdfPath);
                pdfFileStamp.AddStamp(stamp);
                pdfFileStamp.Save(outputPdfPath);
                pdfFileStamp.Close();
            }
        }

        Console.WriteLine($"Stamped PDF saved to '{outputPdfPath}'.");
    }
}
