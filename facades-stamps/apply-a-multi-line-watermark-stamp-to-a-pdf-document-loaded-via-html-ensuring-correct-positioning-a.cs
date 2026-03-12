using System;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Paths
        const string htmlPath = "input.html";          // HTML source
        const string outputPath = "watermarked.pdf";   // Result PDF
        const string watermarkImagePath = "watermark.png"; // Multi‑line watermark image (PNG with transparent background)

        // Verify files exist
        if (!File.Exists(htmlPath))
        {
            Console.Error.WriteLine($"HTML file not found: {htmlPath}");
            return;
        }
        if (!File.Exists(watermarkImagePath))
        {
            Console.Error.WriteLine($"Watermark image not found: {watermarkImagePath}");
            return;
        }

        // Load HTML into a PDF Document (HtmlLoadOptions required)
        using (Document pdfDoc = new Document(htmlPath, new HtmlLoadOptions()))
        {
            // Initialize PdfFileStamp with the loaded document
            using (PdfFileStamp fileStamp = new PdfFileStamp(pdfDoc))
            {
                // Fully‑qualified Stamp to avoid ambiguity between Aspose.Pdf.Stamp and Aspose.Pdf.Facades.Stamp
                Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

                // Bind the multi‑line watermark image to the stamp
                stamp.BindImage(watermarkImagePath);

                // Position the stamp (origin is measured from the lower‑left corner)
                // Example: place it at (100, 400) points
                stamp.SetOrigin(100, 400);

                // Set the size of the stamp (width, height) in points
                // Adjust to fit the image dimensions as needed
                stamp.SetImageSize(200, 100);

                // Make the stamp appear behind page content
                stamp.IsBackground = true;

                // Set opacity (0.0 = fully transparent, 1.0 = fully opaque)
                stamp.Opacity = 0.5f;

                // Add the stamp to all pages of the document
                fileStamp.AddStamp(stamp);

                // Save the stamped PDF
                fileStamp.Save(outputPath);
            }
        }

        Console.WriteLine($"Watermarked PDF saved to '{outputPath}'.");
    }
}