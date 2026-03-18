using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aspose.Words;
using Aspose.Words.Fields;

namespace AsposeWordsParallelBarcode
{
    class Program
    {
        // Entry point
        static void Main()
        {
            // Example list of documents to process.
            // Each tuple contains: input DOCX path, output PDF path, barcode value to embed.
            var documents = new List<(string InputPath, string OutputPath, string BarcodeValue)>
            {
                (@"C:\Docs\Doc1.docx", @"C:\Output\Doc1.pdf", "ABC123"),
                (@"C:\Docs\Doc2.docx", @"C:\Output\Doc2.pdf", "XYZ789"),
                // Add more entries as needed.
            };

            // Process all documents in parallel.
            Parallel.ForEach(documents, docInfo =>
            {
                try
                {
                    ProcessDocument(docInfo.InputPath, docInfo.OutputPath, docInfo.BarcodeValue);
                    Console.WriteLine($"Processed: {Path.GetFileName(docInfo.InputPath)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing {docInfo.InputPath}: {ex.Message}");
                }
            });
        }

        // Loads a DOCX, inserts a QR barcode with the supplied value, and saves as PDF.
        private static void ProcessDocument(string inputPath, string outputPath, string barcodeValue)
        {
            // Load the existing DOCX file.
            Document doc = new Document(inputPath);

            // Insert the barcode at the beginning of the document.
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.MoveToDocumentStart();

            // Insert a MERGEBARCODE field and configure it as a QR code.
            FieldMergeBarcode barcodeField = (FieldMergeBarcode)builder.InsertField(FieldType.FieldMergeBarcode, true);
            barcodeField.BarcodeType = "QR";          // QR code type
            barcodeField.BarcodeValue = barcodeValue; // Value to encode

            // Optionally, customize appearance (colors, scaling, etc.) here.
            // Example: barcodeField.BackgroundColor = "0xFFFFFF";
            // Example: barcodeField.ForegroundColor = "0x000000";

            // Save the modified document directly to PDF.
            doc.Save(outputPath, SaveFormat.Pdf);
        }
    }
}
