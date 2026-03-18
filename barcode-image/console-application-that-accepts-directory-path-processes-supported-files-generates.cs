using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Saving;

namespace BarcodePdfGenerator
{
    class Program
    {
        // Supported input document extensions.
        private static readonly string[] SupportedExtensions = { ".docx", ".doc", ".rtf", ".txt", ".odt" };

        static void Main(string[] args)
        {
            // Expect a single argument: the directory containing source documents.
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: BarcodePdfGenerator <source-directory>");
                return;
            }

            string sourceDir = args[0];

            if (!Directory.Exists(sourceDir))
            {
                Console.WriteLine($"Error: Directory '{sourceDir}' does not exist.");
                return;
            }

            // Create an output folder named 'PdfOutput' inside the source directory.
            string outputDir = Path.Combine(sourceDir, "PdfOutput");
            Directory.CreateDirectory(outputDir);

            // Iterate over each supported file in the directory (non‑recursive).
            foreach (string filePath in Directory.GetFiles(sourceDir))
            {
                string ext = Path.GetExtension(filePath);
                if (Array.IndexOf(SupportedExtensions, ext, 0, SupportedExtensions.Length) < 0)
                    continue; // Skip unsupported files.

                try
                {
                    // Load the document.
                    Document doc = new Document(filePath);
                    DocumentBuilder builder = new DocumentBuilder(doc);

                    // Insert a DISPLAYBARCODE field at the beginning of the document.
                    builder.MoveToDocumentStart();
                    FieldDisplayBarcode barcodeField = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);

                    // Configure the barcode – here we use a QR code that encodes the file name.
                    barcodeField.BarcodeType = "QR";
                    barcodeField.BarcodeValue = Path.GetFileNameWithoutExtension(filePath);
                    barcodeField.BackgroundColor = "0xF8BD69"; // Light orange background.
                    barcodeField.ForegroundColor = "0xB5413B"; // Dark red foreground.
                    barcodeField.ErrorCorrectionLevel = "3";
                    barcodeField.ScalingFactor = "250";
                    barcodeField.SymbolHeight = "1000";
                    barcodeField.SymbolRotation = "0";

                    // Prepare PDF save options (default options are sufficient for this task).
                    PdfSaveOptions pdfOptions = new PdfSaveOptions();

                    // Determine the output PDF file name.
                    string pdfFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
                    string pdfPath = Path.Combine(outputDir, pdfFileName);

                    // Save the document as PDF.
                    doc.Save(pdfPath, pdfOptions);

                    Console.WriteLine($"Processed '{Path.GetFileName(filePath)}' -> '{pdfFileName}'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to process '{Path.GetFileName(filePath)}': {ex.Message}");
                }
            }

            Console.WriteLine("Processing completed.");
        }
    }
}
