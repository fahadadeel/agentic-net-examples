using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Aspose.Pdf.Facades;

class Program
{
    static async Task Main()
    {
        const string inputPdfPath = "sample.pdf";
        const string outputTextPath = "extracted_text.txt";
        const string imagesOutputDir = "ExtractedImages";

        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPdfPath}");
            return;
        }

        // Ensure the images output directory exists
        Directory.CreateDirectory(imagesOutputDir);

        // Run the extraction in a background task so the UI thread (if any) stays responsive
        await Task.Run(() =>
        {
            // Initialize the PdfExtractor facade
            using (PdfExtractor extractor = new PdfExtractor())
            {
                // Bind the PDF file to the extractor
                extractor.BindPdf(inputPdfPath);

                // -----------------------------------------------------------------
                // Extract text
                // -----------------------------------------------------------------
                // Extract the text from the whole document using Unicode encoding
                extractor.ExtractText();

                // Save the extracted text to a file
                // GetText writes the whole document text to the specified path
                extractor.GetText(outputTextPath);

                // -----------------------------------------------------------------
                // Extract images
                // -----------------------------------------------------------------
                // Extract all images from the document
                extractor.ExtractImage();

                int imageIndex = 1;
                // Loop through all extracted images
                while (extractor.HasNextImage())
                {
                    // Build a unique file name for each image
                    string imagePath = Path.Combine(imagesOutputDir, $"image-{imageIndex}.png");

                    // Retrieve the next image and save it to the file.
                    // GetNextImage(string) saves the image using its original format.
                    // Using .png extension works for most common image types.
                    extractor.GetNextImage(imagePath);

                    imageIndex++;
                }

                // Close the extractor (optional, Dispose will also close)
                extractor.Close();
            }
        });

        Console.WriteLine("Extraction completed.");
        Console.WriteLine($"Text saved to: {outputTextPath}");
        Console.WriteLine($"Images saved to folder: {imagesOutputDir}");
    }
}