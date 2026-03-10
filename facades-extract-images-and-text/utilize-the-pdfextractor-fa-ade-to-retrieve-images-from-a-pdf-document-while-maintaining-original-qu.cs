using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Pdf;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPdfPath = "sample.pdf";               // PDF to extract images from
        const string outputFolder = "ExtractedImages";          // Folder to store images

        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPdfPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputFolder);

        // Use PdfExtractor facade – it implements IDisposable, so wrap in using
        using (PdfExtractor extractor = new PdfExtractor())
        {
            // Bind the PDF document
            extractor.BindPdf(inputPdfPath);

            // Extract images that are actually shown on pages (higher relevance)
            extractor.ExtractImageMode = ExtractImageMode.ActuallyUsed;

            // Increase resolution to keep original quality (default is 150 DPI)
            extractor.Resolution = 300; // DPI – adjust as needed

            // Prepare the extractor for image extraction
            extractor.ExtractImage();

            int imageIndex = 1;
            while (extractor.HasNextImage())
            {
                // Build output file name (preserve original format when possible)
                string outputFile = Path.Combine(outputFolder, $"image-{imageIndex}.png");

                // Retrieve the next image and save it as PNG (lossless, retains quality)
                // You can change ImageFormat.Jpeg if you prefer JPEG output
                extractor.GetNextImage(outputFile, ImageFormat.Png);

                Console.WriteLine($"Extracted image {imageIndex} to '{outputFile}'");
                imageIndex++;
            }
        }

        Console.WriteLine("Image extraction completed.");
    }
}