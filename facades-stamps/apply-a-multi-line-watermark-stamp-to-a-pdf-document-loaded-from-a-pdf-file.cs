using System;
using System.IO;
using System.Drawing; // for Color
using Aspose.Pdf.Facades; // PdfFileStamp, Stamp, FormattedText, EncodingType

class Program
{
    static void Main()
    {
        const string inputPdf  = "input.pdf";
        const string outputPdf = "watermarked.pdf";

        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"Input file not found: {inputPdf}");
            return;
        }

        // Initialize the PdfFileStamp facade and bind the source PDF
        PdfFileStamp fileStamp = new PdfFileStamp();
        fileStamp.BindPdf(inputPdf);

        // Create a Stamp object that will hold the watermark
        Stamp stamp = new Stamp();

        // Position the stamp (origin) and set its appearance
        stamp.SetOrigin(100, 400);          // X and Y coordinates (bottom-left origin)
        stamp.SetImageSize(300, 200);       // Width and height of the stamp area
        stamp.Opacity = 0.5f;               // Semi‑transparent
        stamp.IsBackground = true;          // Render behind page content

        // Create multi‑line formatted text for the watermark
        // Newline characters create separate lines
        FormattedText ft = new FormattedText(
            "Confidential\nDo Not Distribute\nCompany XYZ",
            Color.Red,                     // Text color (System.Drawing.Color)
            "Helvetica",                  // Font name
            EncodingType.Winansi,         // Encoding
            false,                        // Do not embed the font
            48);                          // Font size

        // Bind the formatted text to the stamp
        stamp.BindLogo(ft);

        // Add the stamp to the PDF
        fileStamp.AddStamp(stamp);

        // Save the resulting PDF and release resources
        fileStamp.Save(outputPdf);
        fileStamp.Close();
    }
}