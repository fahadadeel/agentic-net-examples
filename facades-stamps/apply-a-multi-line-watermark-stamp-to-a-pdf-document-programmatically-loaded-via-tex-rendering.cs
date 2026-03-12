using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text; // for EncodingType

class Program
{
    static void Main()
    {
        const string texPath = "input.tex";
        const string outputPdf = "watermarked.pdf";

        if (!File.Exists(texPath))
        {
            Console.Error.WriteLine($"TeX file not found: {texPath}");
            return;
        }

        // Load the TeX file and render it to a PDF document in memory
        using (Document pdfDoc = new Document(texPath, new TeXLoadOptions()))
        {
            // Create a multi‑line watermark using FormattedText
            FormattedText watermarkText = new FormattedText(
                "Confidential\nDo Not Distribute\nCompany XYZ", // multi‑line text
                System.Drawing.Color.Red,                      // text color (System.Drawing.Color required)
                "Helvetica",                                   // font name
                EncodingType.Winansi,                          // encoding
                false,                                         // embed font flag
                48);                                           // font size

            // Create a stamp and bind the formatted text to it
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(watermarkText);
            stamp.IsBackground = true;   // place watermark behind page content
            stamp.Opacity = 0.4f;        // semi‑transparent
            stamp.SetOrigin(100, 400);   // position on the page (adjust as needed)

            // Apply the stamp to the PDF using the PdfFileStamp facade
            PdfFileStamp fileStamp = new PdfFileStamp(pdfDoc);
            fileStamp.AddStamp(stamp);
            fileStamp.Save(outputPdf);   // save the watermarked PDF
            fileStamp.Close();           // close the facade
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdf}'.");
    }
}
