using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text;          // for EncodingType
using System.Drawing;          // for System.Drawing.Color (required by FormattedText)

class Program
{
    static void Main()
    {
        // NOTE: The core Aspose.Pdf library does not contain the Aspose.Pdf.OFD namespace.
        // To keep the sample self‑contained we work with a regular PDF file instead of an OFD file.
        // If OFD support is required, add the Aspose.Pdf.OFD NuGet package (or reference Aspose.Pdf.OFD.dll).
        const string pdfInputPath = "input.pdf";   // source PDF file (replace with your file)
        const string pdfOutputPath = "watermarked_output.pdf";

        // Verify that the source PDF file exists before attempting to load it.
        if (!File.Exists(pdfInputPath))
        {
            Console.WriteLine($"Error: Source PDF file '{pdfInputPath}' was not found.\n" +
                              "Please place a valid PDF file at the specified location or update the path.");
            return;
        }

        // Load the PDF document using the core Document constructor.
        using (Document pdfDoc = new Document(pdfInputPath))
        {
            // Initialize the PdfFileStamp facade on the loaded document.
            using (PdfFileStamp fileStamp = new PdfFileStamp(pdfDoc))
            {
                // Create a stamp object (fully qualified to avoid ambiguity).
                Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

                // Build multi‑line formatted text for the watermark.
                // Newlines are represented by '\n' inside the text string.
                FormattedText watermarkText = new FormattedText(
                    "CONFIDENTIAL\nDO NOT DISTRIBUTE", // two lines of text
                    System.Drawing.Color.Red,            // text color (System.Drawing.Color)
                    "Helvetica",                       // font name
                    EncodingType.Winansi,                // encoding
                    false,                               // embed font flag
                    48);                                 // font size

                // Bind the formatted text to the stamp.
                stamp.BindLogo(watermarkText);

                // Position the stamp (origin is the lower‑left corner of the text).
                stamp.SetOrigin(100, 400);

                // Make the stamp appear behind page content and set its opacity.
                stamp.IsBackground = true;
                stamp.Opacity = 0.5f;

                // Add the stamp to the document.
                fileStamp.AddStamp(stamp);

                // Save the resulting PDF with the watermark.
                fileStamp.Save(pdfOutputPath);
            }
        }

        Console.WriteLine($"Watermarked PDF saved to '{pdfOutputPath}'.");
    }
}
