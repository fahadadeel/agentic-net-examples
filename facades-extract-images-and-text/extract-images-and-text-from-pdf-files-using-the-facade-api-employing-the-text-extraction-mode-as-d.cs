using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Input PDF file path (ensure the file exists before proceeding)
        const string inputPdfPath = "input.pdf";

        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Error: The PDF file '{inputPdfPath}' was not found. Please provide a valid path.");
            return;
        }

        // Output text file path (all pages combined)
        const string outputTextPath = "extracted_text.txt";

        // Directory where extracted images will be saved
        const string imagesOutputDir = "ExtractedImages";

        // Ensure the images directory exists
        Directory.CreateDirectory(imagesOutputDir);

        // Use PdfExtractor (Facade) inside a using block for deterministic disposal
        using (PdfExtractor extractor = new PdfExtractor())
        {
            // Bind the PDF file to the extractor
            extractor.BindPdf(inputPdfPath);

            // -------------------------------------------------
            // OPTIONAL: set the text extraction mode (default is Text)
            // -------------------------------------------------
            // extractor.TextExtractionMode = TextExtractionMode.Text; // uncomment if you need a specific mode

            // -------------------------
            // Extract all text (Unicode)
            // -------------------------
            extractor.ExtractText();                     // Perform text extraction
            extractor.GetText(outputTextPath);           // Save extracted text to a file

            // ---------------------------------
            // Extract all images from the PDF
            // ---------------------------------
            extractor.ExtractImage();                    // Prepare image extraction

            int imageIndex = 1;
            while (extractor.HasNextImage())
            {
                // Build a unique file name for each image
                string imagePath = Path.Combine(imagesOutputDir, $"image_{imageIndex}.png");

                // Save the next image to the file (original format is preserved; .png extension is safe)
                extractor.GetNextImage(imagePath);

                imageIndex++;
            }
        }

        Console.WriteLine("Extraction completed.");
        Console.WriteLine($"Text saved to: {outputTextPath}");
        Console.WriteLine($"Images saved to folder: {imagesOutputDir}");
    }
}
