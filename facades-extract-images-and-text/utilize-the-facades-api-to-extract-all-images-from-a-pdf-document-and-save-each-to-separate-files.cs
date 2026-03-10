using System;
using System.IO;
using Aspose.Pdf.Facades; // Facade API for PDF operations

class Program
{
    static void Main()
    {
        // Input PDF file path
        const string inputPdf = "input.pdf";

        // Directory where extracted images will be saved
        const string outputDir = "ExtractedImages";

        // Verify that the source PDF exists
        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"File not found: {inputPdf}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Use PdfExtractor (implements IDisposable) to extract images
        using (PdfExtractor extractor = new PdfExtractor())
        {
            // Bind the PDF document to the extractor
            extractor.BindPdf(inputPdf);

            // Prepare the extractor for image extraction
            extractor.ExtractImage();

            int imageIndex = 1;

            // Loop while there are more images in the PDF
            while (extractor.HasNextImage())
            {
                // Build the output file name (original image format is preserved)
                string outPath = Path.Combine(outputDir, $"image-{imageIndex}.png");

                // Extract the next image and save it. Use the overload that does not require ImageFormat.
                extractor.GetNextImage(outPath);

                imageIndex++;
            }
        }

        Console.WriteLine("All images have been extracted successfully.");
    }
}
