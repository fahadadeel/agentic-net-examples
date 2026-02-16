using System;
using Aspose.Words;
using Aspose.Words.Fields;

class BarcodeFieldExample
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a DISPLAYBARCODE field.
        // Syntax: DISPLAYBARCODE <BarcodeType> "<BarcodeValue>"
        // This field will render the barcode image directly in the document.
        builder.InsertField(@"DISPLAYBARCODE QR ""ABC123""");

        // Add a line break for readability.
        builder.Writeln();

        // Insert a MERGEBARCODE field.
        // Syntax: MERGEBARCODE <BarcodeType> "<BarcodeValue>"
        // This field works with mail‑merge; it will also render the barcode image.
        builder.InsertField(@"MERGEBARCODE QR ""ABC123""");

        // Save the document in DOCX format.
        doc.Save("BarcodeFields.docx");
    }
}
