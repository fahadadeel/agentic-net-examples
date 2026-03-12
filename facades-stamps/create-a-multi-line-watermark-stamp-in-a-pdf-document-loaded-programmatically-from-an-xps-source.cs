using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string xpsPath = "input.xps";
        const string outputPdf = "watermarked.pdf";

        if (!File.Exists(xpsPath))
        {
            Console.Error.WriteLine($"File not found: {xpsPath}");
            return;
        }

        // Load the XPS file into a PDF document.
        using (Document pdfDoc = new Document(xpsPath, new XpsLoadOptions()))
        {
            // Initialize the PdfFileStamp facade with the loaded document.
            PdfFileStamp fileStamp = new PdfFileStamp(pdfDoc);

            // Create multi‑line formatted text for the watermark.
            // Newline characters separate the lines.
            Aspose.Pdf.Facades.FormattedText formattedText = new Aspose.Pdf.Facades.FormattedText(
                "CONFIDENTIAL\nDo Not Distribute",   // text (two lines)
                System.Drawing.Color.Red,            // text color (System.Drawing.Color is required)
                "Helvetica",                         // font name
                Aspose.Pdf.Facades.EncodingType.Winansi,
                false,                               // not embedded
                48);                                 // font size

            // Create a stamp and bind the formatted text to it.
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(formattedText);

            // Configure stamp appearance.
            stamp.SetOrigin(200, 400);   // position (adjust as needed)
            stamp.IsBackground = true;  // place behind page content
            stamp.Opacity = 0.5f;        // semi‑transparent

            // Apply the stamp to all pages of the document.
            fileStamp.AddStamp(stamp);

            // Save the watermarked PDF.
            fileStamp.Save(outputPdf);
            fileStamp.Close();
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdf}'.");
    }
}