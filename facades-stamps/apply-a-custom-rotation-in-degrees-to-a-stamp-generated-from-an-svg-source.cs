using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Paths for the source PDF, the SVG stamp, and the resulting PDF
        const string inputPdfPath  = "input.pdf";
        const string outputPdfPath = "output_rotated_stamp.pdf";
        const string svgStampPath  = "stamp.svg";

        // Desired rotation angle in degrees (can be any value, e.g., 45)
        const float rotationDegrees = 45f;

        // Verify that the required files exist
        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdfPath}");
            return;
        }
        if (!File.Exists(svgStampPath))
        {
            Console.Error.WriteLine($"SVG stamp not found: {svgStampPath}");
            return;
        }

        // Initialize the PdfFileStamp facade with input and output files
        using (PdfFileStamp pdfFileStamp = new PdfFileStamp(inputPdfPath, outputPdfPath))
        {
            // Create a stamp instance (fully qualified to avoid ambiguity)
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

            // Bind the SVG file as the stamp image
            stamp.BindImage(svgStampPath);

            // Apply the custom rotation (degrees)
            stamp.Rotation = rotationDegrees;

            // Optional: set the stamp as background (false = foreground)
            stamp.IsBackground = false;

            // Optional: define the position (origin) of the stamp on the page
            stamp.SetOrigin(100, 200); // X = 100, Y = 200 (points from lower‑left)

            // Optional: define the size of the stamp (width, height)
            stamp.SetImageSize(150, 150); // 150 pt × 150 pt

            // Add the configured stamp to all pages of the document
            pdfFileStamp.AddStamp(stamp);

            // Save changes and release resources
            pdfFileStamp.Close();
        }

        Console.WriteLine($"PDF with rotated SVG stamp saved to '{outputPdfPath}'.");
    }
}