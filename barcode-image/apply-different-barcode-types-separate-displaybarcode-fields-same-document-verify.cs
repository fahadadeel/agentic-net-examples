using System;
using Aspose.Words;
using Aspose.Words.Fields;

class DisplayBarcodeExample
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // 1. QR code with custom colors.
        FieldDisplayBarcode qrField = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
        qrField.BarcodeType = "QR";
        qrField.BarcodeValue = "QR123";
        qrField.BackgroundColor = "0xF8BD69";
        qrField.ForegroundColor = "0xB5413B";
        qrField.ErrorCorrectionLevel = "3";
        qrField.ScalingFactor = "250";
        qrField.SymbolHeight = "1000";
        qrField.SymbolRotation = "0";
        builder.Writeln(); // Move to next line.

        // 2. EAN13 barcode with digits displayed below the bars.
        FieldDisplayBarcode ean13Field = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
        ean13Field.BarcodeType = "EAN13";
        ean13Field.BarcodeValue = "501234567890";
        ean13Field.DisplayText = true;
        ean13Field.PosCodeStyle = "CASE";
        ean13Field.FixCheckDigit = true;
        builder.Writeln();

        // 3. CODE39 barcode with start/stop characters.
        FieldDisplayBarcode code39Field = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
        code39Field.BarcodeType = "CODE39";
        code39Field.BarcodeValue = "12345ABCDE";
        code39Field.AddStartStopChar = true;
        builder.Writeln();

        // 4. ITF14 barcode with a specified case code style.
        FieldDisplayBarcode itf14Field = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
        itf14Field.BarcodeType = "ITF14";
        itf14Field.BarcodeValue = "09312345678907";
        itf14Field.CaseCodeStyle = "STD";
        builder.Writeln();

        // Update all fields to generate their results.
        doc.UpdateFields();

        // Verify each field's code and that a result was generated.
        foreach (Field field in doc.Range.Fields)
        {
            if (field is FieldDisplayBarcode displayField)
            {
                // Output the field code for verification.
                Console.WriteLine(displayField.GetFieldCode());

                // Ensure the field produced a visual result (non‑empty DisplayResult).
                if (string.IsNullOrEmpty(displayField.DisplayResult))
                {
                    Console.WriteLine("Warning: DISPLAYBARCODE field produced no result.");
                }
            }
        }

        // Save the document containing all barcode fields.
        doc.Save("DisplayBarcodeMultiple.docx");
    }
}
