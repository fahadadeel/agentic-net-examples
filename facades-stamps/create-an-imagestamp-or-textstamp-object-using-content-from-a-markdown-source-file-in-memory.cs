using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Paths for the source PDF and the output PDF
        const string inputPdfPath  = "input.pdf";
        const string outputPdfPath = "stamped_output.pdf";

        // Markdown content held in memory (could be read from a file or other source)
        string markdownContent = "# Sample Title\nThis is **markdown** text used for stamping.";

        // Ensure the input PDF exists
        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdfPath}");
            return;
        }

        // Load the PDF document (required for the PdfFileStamp facade)
        using (Document doc = new Document(inputPdfPath))
        {
            // Initialize the PdfFileStamp facade and bind the loaded document
            using (PdfFileStamp pdfFileStamp = new PdfFileStamp())
            {
                pdfFileStamp.BindPdf(doc);

                // Create a FormattedText object that holds the markdown text.
                // FormattedText constructor parameters:
                //   text, text color (System.Drawing.Color), font name, encoding, embed flag, font size
                FormattedText formattedText = new FormattedText(
                    markdownContent,
                    System.Drawing.Color.DarkBlue,
                    "Helvetica",
                    EncodingType.Winansi,
                    false,
                    24);

                // Create a Stamp object (base class for both image and text stamps)
                Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

                // Bind the formatted text to the stamp (text stamp)
                stamp.BindLogo(formattedText);

                // Position the stamp on the page (origin is lower‑left corner)
                stamp.SetOrigin(100, 500);   // X = 100, Y = 500

                // Make the stamp appear as a background element (optional)
                stamp.IsBackground = true;

                // Set opacity (0.0 = fully transparent, 1.0 = fully opaque)
                stamp.Opacity = 0.6f;

                // Add the stamp to all pages of the document
                pdfFileStamp.AddStamp(stamp);

                // Save the modified PDF
                pdfFileStamp.Save(outputPdfPath);
                pdfFileStamp.Close();
            }
        }

        Console.WriteLine($"Stamped PDF saved to '{outputPdfPath}'.");
    }
}