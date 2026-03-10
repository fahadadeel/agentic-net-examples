using System;
using System.IO;
using Aspose.Pdf.Facades;
using System.Drawing.Imaging; // ImageFormat for specifying output format

class Program
{
    static void Main()
    {
        const string pdfPath = "input.pdf";          // source PDF
        const int pageNumber = 2;                    // page to extract images from (1‑based)
        const string outputFolder = "ExtractedImages";

        // Verify source file exists
        if (!File.Exists(pdfPath))
        {
            Console.Error.WriteLine($"File not found: {pdfPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputFolder);

        // Use PdfExtractor (Facade) to pull images from the specified page
        using (PdfExtractor extractor = new PdfExtractor())
        {
            // Bind the PDF document
            extractor.BindPdf(pdfPath);

            // Limit extraction to the desired page
            extractor.StartPage = pageNumber;
            extractor.EndPage   = pageNumber;

            // Perform the extraction
            extractor.ExtractImage();

            int imageIndex = 1;
            // Iterate over all extracted images
            while (extractor.HasNextImage())
            {
                string outPath = Path.Combine(
                    outputFolder,
                    $"page{pageNumber}_image{imageIndex}.png");

                // Save each image; PNG is used here but any ImageFormat is acceptable
                extractor.GetNextImage(outPath, ImageFormat.Png);
                imageIndex++;
            }
        }

        Console.WriteLine("Image extraction completed.");
    }
}