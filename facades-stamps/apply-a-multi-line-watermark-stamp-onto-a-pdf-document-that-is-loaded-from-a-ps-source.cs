using System;
using System.IO;
using System.Drawing;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text;

class Program
{
    static void Main()
    {
        const string inputPs = "input.ps";
        const string outputPdf = "watermarked_output.pdf";

        if (!File.Exists(inputPs))
        {
            Console.Error.WriteLine($"Input file not found: {inputPs}");
            return;
        }

        // Load the PostScript file into a PDF Document
        using (Document doc = new Document(inputPs, new PsLoadOptions()))
        {
            // Initialize the PdfFileStamp facade with the loaded document
            using (PdfFileStamp fileStamp = new PdfFileStamp(doc))
            {
                // Create multi‑line formatted text for the watermark
                FormattedText ft = new FormattedText(
                    "Confidential\nDo Not Distribute\nCompany XYZ",
                    System.Drawing.Color.Red,
                    "Helvetica",
                    EncodingType.Winansi,
                    false,
                    48);

                // Create a stamp and bind the formatted text
                Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
                stamp.BindLogo(ft);
                stamp.IsBackground = true;   // place behind page content
                stamp.Opacity = 0.5f;        // semi‑transparent
                stamp.SetOrigin(100, 400);   // position on the page

                // Add the stamp to the document
                fileStamp.AddStamp(stamp);

                // Save the watermarked PDF
                fileStamp.Save(outputPdf);
            }
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdf}'.");
    }
}
