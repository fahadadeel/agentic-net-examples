using System;
using System.Diagnostics;
using Aspose.Words;
using Aspose.Words.Fields;

class BarcodeVerticalOrientationExample
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a DISPLAYBARCODE field that will render a QR code.
        FieldDisplayBarcode barcodeField = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
        barcodeField.BarcodeType = "QR";
        barcodeField.BarcodeValue = "ABC123";

        // Set the rotation switch to 1 (90 degrees) – this makes the barcode appear vertical.
        barcodeField.SymbolRotation = "1";

        // Optional: add a line break after the field for readability.
        builder.Writeln();

        // Verify that the field code contains the correct rotation switch.
        string fieldCode = barcodeField.GetFieldCode();
        Debug.Assert(fieldCode.Contains("\\r 1"), "The barcode field does not contain the expected rotation switch.");

        // Save the document as PDF. The PDF will show the barcode in vertical orientation.
        doc.Save("BarcodeVertical.pdf");
    }
}
