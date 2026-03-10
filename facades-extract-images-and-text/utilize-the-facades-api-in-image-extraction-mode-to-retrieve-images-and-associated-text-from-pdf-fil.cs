using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        const string inputPdf = "sample.pdf";
        const string imageOutputDir = "ExtractedImages";
        const string textOutputFile = "ExtractedText.txt";

        if (!File.Exists(inputPdf))
        {
            Console.Error.WriteLine($"Input PDF not found: {inputPdf}");
            return;
        }

        // Ensure the image output directory exists
        Directory.CreateDirectory(imageOutputDir);

        try
        {
            // Use PdfExtractor (facade) to bind and extract content
            using (PdfExtractor extractor = new PdfExtractor())
            {
                // Bind the PDF file to the extractor
                extractor.BindPdf(inputPdf);

                // ----------- Extract Images -----------
                extractor.ExtractImage();
                int imageIndex = 1;
                while (extractor.HasNextImage())
                {
                    string imagePath = Path.Combine(imageOutputDir, $"image-{imageIndex}.png");
                    // Save the next image to a file
                    extractor.GetNextImage(imagePath);
                    imageIndex++;
                }

                // ----------- Extract Text -----------
                extractor.ExtractText();               // Extract all text using Unicode encoding
                extractor.GetText(textOutputFile);     // Save the extracted text to a file
            }

            Console.WriteLine("Extraction completed successfully.");
            Console.WriteLine($"Images saved to: {Path.GetFullPath(imageOutputDir)}");
            Console.WriteLine($"Text saved to: {Path.GetFullPath(textOutputFile)}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during extraction: {ex.Message}");
        }
    }
}