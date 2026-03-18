using System;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Saving;

class BarcodeColorExample
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a DISPLAYBARCODE field that will render a QR code.
        FieldDisplayBarcode barcodeField = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);

        // Set barcode parameters, including custom background and foreground colors.
        barcodeField.BarcodeType = "QR";
        barcodeField.BarcodeValue = "ABC123";
        barcodeField.BackgroundColor = "0xF8BD69"; // Light orange background.
        barcodeField.ForegroundColor = "0xB5413B"; // Dark reddish foreground.
        barcodeField.ErrorCorrectionLevel = "3";
        barcodeField.ScalingFactor = "250";
        barcodeField.SymbolHeight = "1000";
        barcodeField.SymbolRotation = "0";

        // Verify that the field code contains the expected switches.
        string expectedFieldCode = " DISPLAYBARCODE  ABC123 QR \\b 0xF8BD69 \\f 0xB5413B \\q 3 \\s 250 \\h 1000 \\r 0";
        if (barcodeField.GetFieldCode() != expectedFieldCode)
            throw new InvalidOperationException("Field code does not match the expected value.");

        // Save the document to PDF, using default options.
        // PdfSaveOptions can be customized if needed (e.g., to force color rendering).
        PdfSaveOptions pdfOptions = new PdfSaveOptions();
        doc.Save("BarcodeWithCustomColors.pdf", pdfOptions);
    }
}
