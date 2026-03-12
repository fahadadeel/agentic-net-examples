using System;
using System.IO;
using System.Drawing; // for System.Drawing.Color
using Aspose.Pdf; // Document, TeXLoadOptions
using Aspose.Pdf.Facades; // PdfFileStamp
using Aspose.Pdf.Text; // FormattedText, EncodingType

class Program
{
    static void Main()
    {
        const string texPath = "input.tex";
        const string outputPdf = "watermarked_output.pdf";

        if (!File.Exists(texPath))
        {
            Console.Error.WriteLine($"TeX source not found: {texPath}");
            return;
        }

        // Load TeX source and convert it to a PDF document
        using (Document pdfDoc = new Document(texPath, new TeXLoadOptions()))
        {
            // Create multi‑line formatted text for the watermark
            FormattedText watermarkText = new FormattedText(
                "Confidential\nDo Not Distribute",
                System.Drawing.Color.Red,
                "Helvetica",
                EncodingType.Winansi,
                false,
                48);

            // Create a stamp and bind the formatted text
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(watermarkText);
            stamp.IsBackground = true;   // place behind existing content
            stamp.Opacity = 0.5f;        // semi‑transparent

            // Apply the stamp to all pages using PdfFileStamp facade
            using (PdfFileStamp fileStamp = new PdfFileStamp(pdfDoc))
            {
                fileStamp.AddStamp(stamp);
                fileStamp.Save(outputPdf);
            }
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdf}'.");
    }
}
