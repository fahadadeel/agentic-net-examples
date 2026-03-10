using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPath = "input.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Use PdfExtractor (facade) to analyze the PDF
        using (PdfExtractor extractor = new PdfExtractor())
        {
            // Bind the PDF file to the extractor
            extractor.BindPdf(inputPath);

            // Extract images and text for the whole document
            extractor.ExtractImage();
            extractor.ExtractText();

            // Check if any images are present
            bool hasImages = extractor.HasNextImage();

            // Check if any textual content is present
            bool hasText = extractor.HasNextPageText();

            Console.WriteLine($"Contains images: {hasImages}");
            Console.WriteLine($"Contains text: {hasText}");
        }
    }
}