using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Input PDF file path
        const string pdfPath = "input.pdf";

        // Output directories for extracted content
        const string imagesDir = "ExtractedImages";
        const string textFile = "ExtractedText.txt";

        // Verify that the source PDF exists before proceeding
        if (!File.Exists(pdfPath))
        {
            Console.Error.WriteLine($"Error: PDF file '{pdfPath}' not found. Please place the file in the working directory or provide a correct path.");
            return;
        }

        // Ensure output folder exists
        Directory.CreateDirectory(imagesDir);

        // Use PdfExtractor (Facade) inside a using block for deterministic disposal
        using (PdfExtractor extractor = new PdfExtractor())
        {
            // Bind the PDF document to the extractor
            extractor.BindPdf(pdfPath);

            // OPTIONAL: limit the page range (default is whole document)
            // extractor.StartPage = 1;
            // extractor.EndPage   = extractor.Document.Pages.Count;

            // -----------------------------------------------------------------
            // Extract images with a specific mode
            // -----------------------------------------------------------------
            // NOTE: The ExtractImageMode property is not available in the
            // version of Aspose.Pdf.Facades referenced by this project.
            // The default behavior extracts all images, so we simply call
            // ExtractImage() without setting a mode.
            // extractor.ExtractImageMode = ExtractImageMode.ActuallyUsed; // <-- removed for compatibility

            // Perform the image extraction operation
            extractor.ExtractImage();

            int imageIndex = 1;
            // Retrieve each extracted image and save it to a file
            while (extractor.HasNextImage())
            {
                // Build a file name for the image (PNG format is default)
                string imagePath = Path.Combine(imagesDir, $"image-{imageIndex}.png");
                extractor.GetNextImage(imagePath);
                imageIndex++;
            }

            // -----------------------------------------------------------------
            // Extract text
            // -----------------------------------------------------------------
            // Perform the text extraction operation (Unicode encoding)
            extractor.ExtractText();

            // Save the whole document text to a single file
            extractor.GetText(textFile);

            // OPTIONAL: extract each page's text into separate files
            // int pageNum = 1;
            // while (extractor.HasNextPageText())
            // {
            //     string pageTextPath = Path.Combine(imagesDir, $"page-{pageNum}.txt");
            //     extractor.GetNextPageText(pageTextPath);
            //     pageNum++;
            // }
        }

        Console.WriteLine("Extraction completed.");
    }
}
