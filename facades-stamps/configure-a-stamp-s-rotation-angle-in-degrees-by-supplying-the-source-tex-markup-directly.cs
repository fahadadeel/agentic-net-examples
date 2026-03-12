using System;
using System.IO;
using System.Drawing;                     // System.Drawing.Color is required for FormattedText
using Aspose.Pdf;                         // Core PDF API
using Aspose.Pdf.Facades;                 // Facade API for stamping
using Aspose.Pdf.Text;                    // For EncodingType enum

class Program
{
    static void Main()
    {
        const string inputPdf  = "input.pdf";
        const string outputPdf = "output.pdf";

        // TeX markup to be used as stamp content
        const string texMarkup = @"\\frac{a}{b} = c";

        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"File not found: {inputPdf}");
            return;
        }

        // Load the source PDF
        using (Document doc = new Document(inputPdf))
        {
            // Create a stamp instance (Aspose.Pdf.Facades.Stamp)
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

            // Bind the TeX markup as formatted text.
            // FormattedText constructor expects System.Drawing.Color, not Aspose.Pdf.Color.
            Aspose.Pdf.Facades.FormattedText formatted = new Aspose.Pdf.Facades.FormattedText(
                texMarkup,                     // TeX source string
                System.Drawing.Color.Black,    // Text color (System.Drawing.Color)
                "Helvetica",                 // Font name
                EncodingType.Winansi,          // Encoding
                false,                         // Embedded flag
                24);                           // Font size

            stamp.BindLogo(formatted);

            // Set rotation angle in degrees (e.g., 45°)
            stamp.Rotation = 45f;

            // Apply the stamp to the document using PdfFileStamp facade
            using (PdfFileStamp fileStamp = new PdfFileStamp())
            {
                fileStamp.BindPdf(doc);      // Initialize with the loaded document
                fileStamp.AddStamp(stamp);   // Add the configured stamp
                fileStamp.Save(outputPdf);   // Save the result
                fileStamp.Close();           // Close the facade
            }
        }

        Console.WriteLine($"Stamped PDF saved to '{outputPdf}'.");
    }
}
