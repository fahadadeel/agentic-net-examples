using System;
using System.IO;
using System.Drawing;                     // needed for System.Drawing.Color
using Aspose.Pdf.Facades;                // Facade APIs for stamping

class Program
{
    static void Main()
    {
        const string inputPath  = "input.pdf";   // source PDF
        const string outputPath = "output.pdf";  // destination PDF
        const float rotationDeg = 45f;           // desired rotation angle in degrees

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Initialize the PdfFileStamp facade and bind the source PDF
        PdfFileStamp fileStamp = new PdfFileStamp();
        fileStamp.BindPdf(inputPath);

        // Create a stamp instance
        Stamp stamp = new Stamp();

        // Bind a simple text logo to the stamp (you can bind an image or another PDF page as needed)
        FormattedText ft = new FormattedText(
            "CONFIDENTIAL",          // text
            Color.Red,               // text color (System.Drawing.Color)
            "Helvetica",             // font name
            EncodingType.Winansi,    // encoding
            false,                   // embed font?
            36);                     // font size
        stamp.BindLogo(ft);

        // Apply the rotation angle (arbitrary angle allowed)
        stamp.Rotation = rotationDeg;   // property from Aspose.Pdf.Facades.Stamp

        // Add the configured stamp to the document
        fileStamp.AddStamp(stamp);

        // Save the stamped PDF and release resources
        fileStamp.Save(outputPath);
        fileStamp.Close();

        Console.WriteLine($"Stamped PDF saved to '{outputPath}' with rotation {rotationDeg} degrees.");
    }
}