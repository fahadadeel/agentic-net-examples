// ALL ATTEMPTS FAILED. Below is the last generated code.

using System;
using Aspose.Words;
using Aspose.Words.Fields;

class BarcodeExample
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a MERGEBARCODE field at the current cursor position.
        // The InsertField method returns a generic Field object, so cast it to FieldMergeBarcode.
        FieldMergeBarcode barcodeField = (FieldMergeBarcode)builder.InsertField(FieldType.FieldMergeBarcode, false);

        // Configure the barcode properties.
        barcodeField.BarcodeType = "QR";          // Type of barcode (QR, CODE39, EAN13, etc.).
        barcodeField.BarcodeValue = "ABC123";    // Data to encode.
        barcodeField.DisplayText = true;         // Show the encoded text below the barcode.
        barcodeField.ScalingFactor = 250;        // Optional: increase size (percentage).

        // Optionally add a line break after the barcode.
        builder.Writeln();

        // Save the document in DOCX format.
        doc.Save("BarcodeDocument.docx");
    }
}
