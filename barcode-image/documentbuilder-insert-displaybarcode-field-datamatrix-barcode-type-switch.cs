using Aspose.Words;
using Aspose.Words.Fields;

class Program
{
    static void Main()
    {
        // Create a new empty document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a DISPLAYBARCODE field.
        FieldDisplayBarcode field = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
        // Set the barcode type to DataMatrix and provide the value to encode.
        field.BarcodeType = "DATAMATRIX";
        field.BarcodeValue = "ABC123";

        // Optional: adjust appearance of the barcode.
        field.SymbolHeight = "800";      // Height in twips (1/1440 inch).
        field.ScalingFactor = "200";    // Scale as a percentage.

        // Add a line break after the field for readability.
        builder.Writeln();

        // Save the document.
        doc.Save("DisplayBarcodeDataMatrix.docx");
    }
}
