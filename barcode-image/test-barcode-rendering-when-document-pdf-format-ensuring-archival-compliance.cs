using System;
using Aspose.Words;
using Aspose.Words.Saving;
using Aspose.Words.Fields;

namespace BarcodePdfATestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BarcodePdfATest.Run();
        }
    }

    public static class BarcodePdfATest
    {
        public static void Run()
        {
            // Create a new blank document.
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Insert a MERGEBARCODE field that will render a QR code.
            // The field type is FieldMergeBarcode, which supports barcode parameters.
            FieldMergeBarcode barcodeField = (FieldMergeBarcode)builder.InsertField(FieldType.FieldMergeBarcode, true);
            barcodeField.BarcodeType = "QR";          // QR code type.
            barcodeField.BarcodeValue = "12345";      // Data to encode.
            barcodeField.ScalingFactor = "250";       // Optional scaling.
            barcodeField.SymbolHeight = "1000";       // Optional height.

            // Configure PDF/A-1b compliance for archival purposes.
            PdfSaveOptions saveOptions = new PdfSaveOptions
            {
                Compliance = PdfCompliance.PdfA1b
            };

            // Save the document as a PDF/A-1b file.
            doc.Save("BarcodePdfA1b.pdf", saveOptions);
        }
    }
}
