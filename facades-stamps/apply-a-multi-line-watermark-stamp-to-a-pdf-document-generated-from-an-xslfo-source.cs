using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text;

class Program
{
    static void Main()
    {
        const string xslFoPath = "input.xslfo";
        const string outputPath = "watermarked.pdf";

        if (!File.Exists(xslFoPath))
        {
            Console.Error.WriteLine($"XSL-FO file not found: {xslFoPath}");
            return;
        }

        // Load the XSL‑FO source into a PDF document using the required load options.
        using (Document pdfDoc = new Document(xslFoPath, new XslFoLoadOptions()))
        {
            // Initialize PdfFileStamp with the loaded document (no obsolete InputFile/OutputFile usage).
            using (PdfFileStamp fileStamp = new PdfFileStamp(pdfDoc))
            {
                // Create multi‑line formatted text for the watermark.
                FormattedText ft = new FormattedText(
                    "Confidential\nDo Not Distribute\nFor Internal Use Only",
                    System.Drawing.Color.Red,
                    "Helvetica",
                    EncodingType.Winansi,
                    false,
                    48);

                // Configure the stamp: bind the formatted text, set position, opacity, and background flag.
                Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
                stamp.BindLogo(ft);          // attach the multi‑line text to the stamp
                stamp.SetOrigin(100, 400);   // X and Y coordinates (from bottom‑left)
                stamp.Opacity = 0.3f;        // semi‑transparent watermark
                stamp.IsBackground = true;   // render behind existing page content

                // Add the stamp to the document (applies to all pages).
                fileStamp.AddStamp(stamp);

                // Save the stamped PDF to the desired output file.
                fileStamp.Save(outputPath);
                fileStamp.Close(); // finalize the facade
            }
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPath}'.");
    }
}
