using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Paths for the source MHT file and the resulting PDF.
        const string mhtPath   = "input.mht";
        const string outputPdf = "watermarked_output.pdf";

        if (!File.Exists(mhtPath))
        {
            Console.Error.WriteLine($"MHT file not found: {mhtPath}");
            return;
        }

        // Load the MHT file into a PDF Document using MhtLoadOptions.
        MhtLoadOptions loadOptions = new MhtLoadOptions();
        using (Document pdfDoc = new Document(mhtPath, loadOptions))
        {
            // Initialize the PdfFileStamp facade and bind it to the loaded document.
            PdfFileStamp fileStamp = new PdfFileStamp();
            fileStamp.BindPdf(pdfDoc);

            // Create a multi‑line watermark using FormattedText.
            // The constructor parameters are:
            //   text, text color (System.Drawing.Color), font name, encoding, isBold, font size.
            FormattedText watermarkText = new FormattedText(
                "CONFIDENTIAL\nDo Not Distribute",
                System.Drawing.Color.Red,
                "Helvetica",
                EncodingType.Winansi,
                false,
                48);

            // Create a Stamp object (fully qualified to avoid ambiguity) and bind the text.
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(watermarkText);

            // Configure stamp appearance: position, rotation, background, opacity.
            stamp.SetOrigin(100, 400);          // X and Y coordinates (points).
            stamp.Rotation = 45;                // Rotate 45 degrees.
            stamp.IsBackground = true;          // Render behind page content.
            stamp.Opacity = 0.3f;               // Semi‑transparent.

            // Apply the stamp to all pages of the document.
            fileStamp.AddStamp(stamp);

            // Save the watermarked PDF.
            fileStamp.Save(outputPdf);
            fileStamp.Close();
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdf}'.");
    }
}