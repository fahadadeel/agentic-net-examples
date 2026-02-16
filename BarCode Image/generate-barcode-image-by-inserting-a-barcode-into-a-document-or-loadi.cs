using System;
using Aspose.Words;
using Aspose.Words.Fields;

class BarcodeExample
{
    static void Main()
    {
        // Create a new empty document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Build a MERGEBARCODE field that will generate a CODE39 barcode.
        // Switches:
        //   \b – barcode type
        //   \d – barcode value
        //   \s – add start/stop characters (optional for CODE39)
        FieldBuilder barcodeBuilder = new FieldBuilder(FieldType.FieldMergeBarcode);
        barcodeBuilder.AddSwitch("\\b", "CODE39");          // Set barcode type.
        barcodeBuilder.AddSwitch("\\d", "12345ABCDE");     // Set barcode value.
        barcodeBuilder.AddSwitch("\\s");                   // Add start/stop characters.

        // Insert the field at the current cursor position.
        barcodeBuilder.BuildAndInsert(builder.CurrentParagraph);

        // Update fields so the barcode image is generated.
        doc.UpdateFields();

        // Save the document in DOCX format.
        doc.Save("BarcodeDocument.docx");
    }
}
