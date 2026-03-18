using System;
using Aspose.Words;
using Aspose.Words.Fields;

class Program
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Sample data whose length will determine the barcode width.
        string[] values = { "12345", "1234567890", "ABCDEFGHIJKLMNO", "SHORT" };

        foreach (string value in values)
        {
            // Insert a DISPLAYBARCODE field.
            FieldDisplayBarcode barcodeField = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);

            // Set the barcode type and value.
            barcodeField.BarcodeType = "CODE39";
            barcodeField.BarcodeValue = value;
            barcodeField.AddStartStopChar = true; // Show start/stop characters for CODE39.

            // Compute a scaling factor based on the length of the value.
            // Base factor is 250; each character adds 10 points.
            int scalingFactor = 250 + (value.Length * 10);
            // Ensure the factor stays within the valid range [10, 1000].
            scalingFactor = Math.Max(10, Math.Min(1000, scalingFactor));
            barcodeField.ScalingFactor = scalingFactor.ToString();

            // Move to the next line for the next barcode.
            builder.Writeln();
        }

        // Save the document.
        doc.Save("VariableWidthBarcodes.docx");
    }
}
