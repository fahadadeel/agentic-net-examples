using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string xslFoPath = "input.fo";
        const string outputPdfPath = "watermarked_output.pdf";

        if (!File.Exists(xslFoPath))
        {
            Console.Error.WriteLine($"XSL-FO file not found: {xslFoPath}");
            return;
        }

        // Load XSL‑FO into a PDF document
        using (Document doc = new Document(xslFoPath, new XslFoLoadOptions()))
        {
            // Initialize PdfFileStamp with the loaded document
            using (PdfFileStamp fileStamp = new PdfFileStamp(doc))
            {
                // Create multi‑line formatted text for the watermark
                Aspose.Pdf.Facades.FormattedText ft = new Aspose.Pdf.Facades.FormattedText(
                    "CONFIDENTIAL\nDo Not Distribute", // text (newline creates multiple lines)
                    System.Drawing.Color.Red,          // text color
                    "Helvetica",                       // font name
                    EncodingType.Winansi,              // encoding
                    false,                             // embed font flag
                    48);                               // font size

                // Create a stamp and bind the formatted text
                Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
                stamp.BindLogo(ft);

                // Configure stamp appearance
                stamp.SetOrigin(100, 400);   // position on the page
                stamp.Rotation = 45f;        // rotate 45 degrees
                stamp.Opacity = 0.5f;        // semi‑transparent
                stamp.IsBackground = true;   // render behind existing content

                // Apply the stamp to all pages (default behavior)
                fileStamp.AddStamp(stamp);

                // Save the final PDF with the watermark
                fileStamp.Save(outputPdfPath);
                fileStamp.Close();
            }
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdfPath}'.");
    }
}