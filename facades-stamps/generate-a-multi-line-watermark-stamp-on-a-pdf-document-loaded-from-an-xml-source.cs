using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text; // for EncodingType

class Program
{
    static void Main()
    {
        const string xmlPath = "input.xml";
        const string outputPath = "watermarked.pdf";

        if (!File.Exists(xmlPath))
        {
            Console.Error.WriteLine($"XML file not found: {xmlPath}");
            return;
        }

        // Load PDF content from the XML source
        using (Document doc = new Document())
        {
            doc.BindXml(xmlPath);

            // Create a multi‑line watermark using FormattedText
            FormattedText watermarkText = new FormattedText(
                "Confidential\nDo Not Distribute\nCompany XYZ",   // three lines
                System.Drawing.Color.LightGray,                  // text color (System.Drawing required)
                "Helvetica",                                     // font name
                EncodingType.Winansi,                            // encoding
                false,                                           // embed font flag
                72);                                             // font size

            // Configure the stamp (use fully‑qualified name to avoid ambiguity)
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(watermarkText);   // set the text as the stamp content
            stamp.IsBackground = true;       // place the stamp behind page content
            stamp.Opacity = 0.5f;            // semi‑transparent
            stamp.SetOrigin(0, 0);           // origin at page center (default alignment)

            // Apply the stamp to all pages via PdfFileStamp facade
            using (PdfFileStamp fileStamp = new PdfFileStamp(doc))
            {
                fileStamp.AddStamp(stamp);
                // No explicit Close() needed; the using block will dispose.
            }

            // Save the watermarked PDF
            doc.Save(outputPath);
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPath}'.");
    }
}
