using Aspose.Words;
using Aspose.Words.Fields;

class Program
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a DISPLAYBARCODE field.
        FieldDisplayBarcode field = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);

        // Set the barcode value and type.
        field.BarcodeValue = "ABC123";
        field.BarcodeType = "QR";

        // Configure the symbol height (in twips) and width (scaling factor).
        // Height: 1500 twips = 1.04 inches.
        // Width: 300% of the default size.
        field.SymbolHeight = "1500";
        field.ScalingFactor = "300";

        // Optional: set additional appearance options.
        field.BackgroundColor = "0xF8BD69";
        field.ForegroundColor = "0xB5413B";

        // Add a line break after the field for readability.
        builder.Writeln();

        // Save the document to disk.
        doc.Save("DisplayBarcodeHeightWidth.docx");
    }
}
