using System;
using System.IO;
using System.Drawing;
using System.Text;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string xmlPath = "input.xml";
        const string outputPdf = "watermarked.pdf";

        if (!File.Exists(xmlPath))
        {
            Console.Error.WriteLine($"XML source not found: {xmlPath}");
            return;
        }

        // Load PDF content from the XML source
        using (Document doc = new Document())
        {
            doc.BindXml(xmlPath);

            // Define multi‑line watermark text
            string watermarkText = "CONFIDENTIAL\nDo Not Distribute\nCompany XYZ";

            // FormattedText constructor sets text, color, font, encoding, embed flag, and size
            FormattedText ft = new FormattedText(
                watermarkText,
                System.Drawing.Color.Red,
                "Helvetica",
                EncodingType.Winansi,
                false,
                48);

            // Create a stamp and bind the formatted text
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(ft);
            stamp.IsBackground = true;          // place behind page content
            stamp.Opacity = 0.3f;                // semi‑transparent
            stamp.SetOrigin(0, 0);               // origin at lower‑left

            // Apply the stamp to the entire document
            PdfFileStamp fileStamp = new PdfFileStamp();
            fileStamp.BindPdf(doc);
            fileStamp.AddStamp(stamp);
            fileStamp.Close(); // finalize stamping

            // Save the watermarked PDF
            doc.Save(outputPdf);
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdf}'.");
    }
}
