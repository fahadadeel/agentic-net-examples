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
        const string ofdPath = "input.ofd";
        const string tempPdfPath = "temp.pdf";
        const string outputPdfPath = "watermarked.pdf";

        if (!File.Exists(ofdPath))
        {
            Console.Error.WriteLine($"File not found: {ofdPath}");
            return;
        }

        // Convert OFD to PDF (load OFD, save as PDF)
        using (Document doc = new Document(ofdPath, new OfdLoadOptions()))
        {
            doc.Save(tempPdfPath);
        }

        // Create multi‑line watermark text
        FormattedText watermarkText = new FormattedText(
            "Confidential\nDo Not Distribute",
            System.Drawing.Color.Red,
            "Helvetica",
            EncodingType.Winansi,
            false,
            48);

        // Configure stamp with the formatted text (use fully‑qualified Stamp to avoid ambiguity)
        Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
        stamp.BindLogo(watermarkText);
        stamp.IsBackground = true;          // place behind page content
        stamp.Opacity = 0.3f;                // semi‑transparent
        stamp.SetOrigin(100, 400);           // position on the page
        stamp.SetImageSize(200, 100);        // size of the text box

        // Apply the stamp to the PDF using PdfFileStamp
        using (PdfFileStamp fileStamp = new PdfFileStamp())
        {
            fileStamp.BindPdf(tempPdfPath);
            fileStamp.AddStamp(stamp);
            fileStamp.Save(outputPdfPath);
        }

        // Clean up temporary PDF
        try { File.Delete(tempPdfPath); } catch { }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdfPath}'.");
    }
}
