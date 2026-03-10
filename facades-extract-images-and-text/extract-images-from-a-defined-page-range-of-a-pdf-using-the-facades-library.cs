using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Input PDF file path
        const string inputPdf = "input.pdf";

        // Output directory for extracted images
        const string outputDir = "ExtractedImages";

        // Define the page range (1‑based indexing)
        const int startPage = 2;
        const int endPage   = 5;

        // Validate input file
        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"Input file not found: {inputPdf}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        try
        {
            // Initialize the PdfExtractor facade
            using (PdfExtractor extractor = new PdfExtractor())
            {
                // Bind the source PDF file
                extractor.BindPdf(inputPdf);

                // Set the page range for image extraction
                extractor.StartPage = startPage;
                extractor.EndPage   = endPage;

                // Extract images from the specified pages
                extractor.ExtractImage();

                int imageIndex = 1;
                // Retrieve each extracted image and save it to a file
                while (extractor.HasNextImage())
                {
                    string imagePath = Path.Combine(
                        outputDir,
                        $"image_page{startPage}_#{imageIndex}.jpg"); // default format is JPEG

                    extractor.GetNextImage(imagePath);
                    Console.WriteLine($"Saved image: {imagePath}");
                    imageIndex++;
                }

                // Release resources associated with the extractor
                extractor.Close();
            }

            Console.WriteLine("Image extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during extraction: {ex.Message}");
        }
    }
}