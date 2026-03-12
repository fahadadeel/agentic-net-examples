using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text; // FormattedText, EncodingType

class Program
{
    static void Main()
    {
        const string htmlPath = "input.html";
        const string outputPdf = "watermarked.pdf";

        if (!File.Exists(htmlPath))
        {
            Console.Error.WriteLine($"HTML file not found: {htmlPath}");
            return;
        }

        // Load HTML content and convert it to a PDF document in memory
        using (Document pdfDoc = new Document(htmlPath, new HtmlLoadOptions()))
        {
            // Create multi‑line formatted text for the watermark
            FormattedText ft = new FormattedText(
                "Confidential\nDo Not Distribute", // text with line break
                System.Drawing.Color.Red,          // text color (required System.Drawing.Color)
                "Helvetica",                       // font name
                EncodingType.Winansi,
                false,                             // embed font flag
                48);                               // font size

            // Create a stamp and bind the formatted text to it
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(ft);          // attach the text to the stamp
            stamp.IsBackground = true;  // render behind page content
            stamp.Opacity = 0.3f;        // semi‑transparent
            stamp.SetOrigin(100, 400);   // optional position on the page

            // Apply the stamp to all pages using the PdfFileStamp facade
            using (PdfFileStamp fileStamp = new PdfFileStamp(pdfDoc))
            {
                fileStamp.AddStamp(stamp);
                fileStamp.Close(); // finalize changes
            }

            // Save the watermarked PDF
            pdfDoc.Save(outputPdf);
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdf}'.");
    }
}
