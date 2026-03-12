using System;
using System.IO;
using Aspose.Pdf.Facades;   // Facade API (PdfFileStamp, Stamp, FormattedText, EncodingType)
using Aspose.Pdf;           // Core API (if needed for other types)

class Program
{
    static void Main()
    {
        const string inputPath  = "input.pdf";
        const string outputPath = "watermarked.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Initialize the PdfFileStamp facade and bind the source PDF.
        PdfFileStamp fileStamp = new PdfFileStamp();
        fileStamp.BindPdf(inputPath);

        // Multi‑line watermark text.
        string watermarkText = "CONFIDENTIAL\nDo Not Distribute\nCompany XYZ";

        // Create formatted text for the watermark.
        // Color uses System.Drawing.Color (fully qualified) to avoid ambiguity.
        FormattedText formattedText = new FormattedText(
            watermarkText,
            System.Drawing.Color.FromArgb(128, 255, 0, 0), // semi‑transparent red
            "Helvetica",
            EncodingType.Winansi,
            false,   // not bold
            48);     // font size

        // Create a stamp and bind the formatted text.
        Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
        stamp.BindLogo(formattedText);

        // Position the stamp (origin is lower‑left corner of the page).
        stamp.SetOrigin(200, 400);

        // Render the stamp as a background so existing content stays on top.
        stamp.IsBackground = true;

        // Optional opacity (0.0 to 1.0).
        stamp.Opacity = 0.3f;

        // Apply the stamp to all pages of the document.
        fileStamp.AddStamp(stamp);

        // Save the watermarked PDF.
        fileStamp.Save(outputPath);

        // Release resources.
        fileStamp.Close();

        Console.WriteLine($"Watermarked PDF saved to '{outputPath}'.");
    }
}