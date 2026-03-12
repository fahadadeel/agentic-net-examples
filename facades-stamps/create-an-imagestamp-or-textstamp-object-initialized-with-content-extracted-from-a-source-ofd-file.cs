using System;
using System.IO;
using System.Text;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string ofdPath = "source.ofd";      // OFD source file
        const string pdfPath = "target.pdf";      // PDF to which the stamp will be applied
        const string outputPath = "stamped.pdf"; // Resulting PDF

        // Verify input files exist
        if (!File.Exists(ofdPath))
        {
            Console.Error.WriteLine($"OFD file not found: {ofdPath}");
            return;
        }
        if (!File.Exists(pdfPath))
        {
            Console.Error.WriteLine($"PDF file not found: {pdfPath}");
            return;
        }

        // Load the OFD file (input format) using the appropriate load options
        using (Document ofdDoc = new Document(ofdPath, new OfdLoadOptions()))
        {
            // Extract all text from the OFD (now represented as a PDF document)
            TextAbsorber absorber = new TextAbsorber();
            ofdDoc.Pages.Accept(absorber);
            string extractedText = absorber.Text?.Trim() ?? string.Empty;

            // ------------------------------------------------------------
            // Build a Facades Stamp that contains the extracted text.
            // ------------------------------------------------------------
            // 1. Create a FormattedText instance – this is the only way to embed
            //    text into a Facades.Stamp (TextStamp belongs to the core API and
            //    cannot be passed to PdfFileStamp.AddStamp).
            FormattedText ft = new FormattedText(
                extractedText,
                System.Drawing.Color.Black,          // text colour
                "Helvetica",                         // font name
                EncodingType.Winansi,
                false,                                // isBold
                12);                                   // font size

            // 2. Create the Facades stamp and bind the FormattedText.
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(ft);

            // 3. Position, opacity and background settings.
            stamp.SetOrigin(100, 500);   // X and Y coordinates (points)
            stamp.IsBackground = true;   // render behind page content
            stamp.Opacity = 0.5f;        // 50 % opacity

            // Apply the stamp to the target PDF using the PdfFileStamp facade
            using (PdfFileStamp fileStamp = new PdfFileStamp())
            {
                fileStamp.BindPdf(pdfPath);   // Load the PDF to be stamped
                fileStamp.AddStamp(stamp);    // Add the prepared stamp
                fileStamp.Save(outputPath);   // Save the stamped PDF
                fileStamp.Close();            // Release resources
            }

            Console.WriteLine($"Stamp applied successfully. Output saved to '{outputPath}'.");
        }
    }
}
