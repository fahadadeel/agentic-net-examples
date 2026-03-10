using System;
using System.IO;
using Aspose.Pdf.Facades;

class Program
{
    static void Main()
    {
        // Paths for the source PDF and the extracted text file
        const string inputPdfPath = "input.pdf";
        const string outputTxtPath = "extracted_text.txt";

        // Verify that the input PDF exists
        if (!File.Exists(inputPdfPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPdfPath}");
            return;
        }

        // PdfExtractor implements IDisposable, so use a using block for deterministic cleanup
        using (PdfExtractor extractor = new PdfExtractor())
        {
            // Bind the PDF file to the extractor facade
            extractor.BindPdf(inputPdfPath);

            // Preserve layout and formatting:
            // 0 = Pure text mode (default) retains basic formatting.
            // 1 = Raw ordering mode keeps the original order without formatting.
            // Choose 0 for a balance of readability and layout preservation.
            extractor.ExtractTextMode = 0;

            // Perform the extraction operation
            extractor.ExtractText();

            // Save the extracted text to a file
            extractor.GetText(outputTxtPath);
        }

        Console.WriteLine($"Text successfully extracted to '{outputTxtPath}'.");
    }
}