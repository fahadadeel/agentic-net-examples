using System;
using System.IO;
using System.Drawing; // for System.Drawing.Color
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string pclPath = "input.pcl";
        const string outputPdfPath = "watermarked_output.pdf";

        if (!File.Exists(pclPath))
        {
            Console.Error.WriteLine($"File not found: {pclPath}");
            return;
        }

        // Load the PCL file into a PDF Document using PclLoadOptions
        using (Document pdfDoc = new Document(pclPath, new PclLoadOptions()))
        {
            // Initialize PdfFileStamp with the loaded document
            PdfFileStamp fileStamp = new PdfFileStamp(pdfDoc);

            // Create multi‑line formatted text for the watermark
            FormattedText watermarkText = new FormattedText(
                "CONFIDENTIAL\nDo Not Distribute",
                System.Drawing.Color.Red,
                "Helvetica",
                EncodingType.Winansi,
                false,
                48);

            // Create a Stamp object and bind the formatted text to it
            Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();
            stamp.BindLogo(watermarkText);
            stamp.IsBackground = true;
            stamp.Opacity = 0.5f;

            // Position the stamp (origin is bottom‑left)
            stamp.SetOrigin(100, 400);

            // Add the stamp to the document
            fileStamp.AddStamp(stamp);

            // Save the watermarked PDF
            fileStamp.Save(outputPdfPath);
            fileStamp.Close();
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPdfPath}'.");
    }
}
