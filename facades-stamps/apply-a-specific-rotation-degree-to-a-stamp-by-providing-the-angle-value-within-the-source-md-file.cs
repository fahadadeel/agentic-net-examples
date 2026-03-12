using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Paths for the source PDF, the stamp PDF, the markdown file containing the angle, and the output PDF
        const string inputPdfPath   = "input.pdf";
        const string stampPdfPath   = "stamp.pdf";
        const string angleMdPath    = "angle.md";
        const string outputPdfPath  = "output.pdf";

        // Ensure all required files exist
        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdfPath}");
            return;
        }
        if (!File.Exists(stampPdfPath))
        {
            Console.Error.WriteLine($"Stamp PDF not found: {stampPdfPath}");
            return;
        }
        if (!File.Exists(angleMdPath))
        {
            Console.Error.WriteLine($"Angle markdown file not found: {angleMdPath}");
            return;
        }

        // Read the rotation angle from the markdown file.
        // The file is expected to contain a single numeric value (e.g., "45").
        float rotationAngle;
        try
        {
            string angleText = File.ReadAllText(angleMdPath).Trim();
            rotationAngle = float.Parse(angleText);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to read or parse rotation angle: {ex.Message}");
            return;
        }

        // Initialize the PdfFileStamp facade and bind the input PDF.
        PdfFileStamp fileStamp = new PdfFileStamp();
        fileStamp.BindPdf(inputPdfPath);

        // Create a stamp that uses the first page of the stamp PDF.
        Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
        stamp.BindPdf(stampPdfPath, 1);          // Use page 1 of the stamp PDF as the stamp content
        stamp.IsBackground = false;              // Place the stamp on top of page content
        // Apply the arbitrary rotation angle read from the MD file.
        // The correct property for rotation on Aspose.Pdf.Facades.Stamp is "Rotation" (not "RotateAngle").
        stamp.Rotation = rotationAngle;

        // Add the configured stamp to the document.
        fileStamp.AddStamp(stamp);

        // Save the result and close the facade.
        fileStamp.Save(outputPdfPath);
        fileStamp.Close();

        Console.WriteLine($"Stamp applied with rotation {rotationAngle}° and saved to '{outputPdfPath}'.");
    }
}
