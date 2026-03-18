using Aspose.Words;
using Aspose.Words.Fields;

class Program
{
    static void Main()
    {
        // Create a new blank Word document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a DISPLAYBARCODE field and update it immediately.
        FieldDisplayBarcode displayBarcode = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);

        // Set the essential properties of the barcode.
        displayBarcode.BarcodeValue = "ABC123";   // Data to encode.
        displayBarcode.BarcodeType = "QR";       // Type of barcode (QR code in this example).

        // Save the document in DOCX format.
        doc.Save("DisplayBarcode.docx");
    }
}
