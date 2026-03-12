using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string cgmPath    = "input.cgm";      // CGM source file
        const string outputPath = "watermarked.pdf"; // Result PDF

        if (!File.Exists(cgmPath))
        {
            Console.Error.WriteLine($"File not found: {cgmPath}");
            return;
        }

        // Load the CGM file into a PDF document using the appropriate load options.
        using (Document doc = new Document(cgmPath, new CgmLoadOptions()))
        {
            // Create multi‑line formatted text for the watermark.
            // Newline characters create separate lines.
            FormattedText ft = new FormattedText(
                "CONFIDENTIAL\nDo Not Distribute\nFor Internal Use Only",
                System.Drawing.Color.Red,          // Text color (System.Drawing.Color is required)
                "Helvetica",                       // Font name
                EncodingType.Winansi,              // Encoding
                false,                             // IsEmbedded (false = use system font)
                48);                               // Font size

            // Configure the stamp that will carry the formatted text.
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(ft);                    // Attach the text to the stamp.
            stamp.IsBackground = true;             // Place the stamp behind page content.
            stamp.Opacity = 0.5f;                  // Semi‑transparent.
            stamp.SetOrigin(100, 400);             // Position (X, Y) in points.

            // Apply the stamp to the entire document using PdfFileStamp.
            using (Aspose.Pdf.Facades.PdfFileStamp fileStamp = new Aspose.Pdf.Facades.PdfFileStamp(doc))
            {
                fileStamp.AddStamp(stamp);
                fileStamp.Save(outputPath);        // Persist the watermarked PDF.
                fileStamp.Close();                 // Optional explicit close.
            }
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPath}'.");
    }
}