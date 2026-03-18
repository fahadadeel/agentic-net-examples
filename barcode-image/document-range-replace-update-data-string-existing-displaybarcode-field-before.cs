using System;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Replacing;

class UpdateDisplayBarcode
{
    static void Main()
    {
        // Paths to the source document (containing a DISPLAYBARCODE field) and the output file.
        const string inputPath = "input.docx";
        const string outputPath = "output.pdf";

        // Load the existing document.
        Document doc = new Document(inputPath);

        // The barcode value we want to replace and the new value.
        const string oldBarcodeValue = "ABC123";
        const string newBarcodeValue = "XYZ789";

        // Prepare replace options – case‑sensitive, replace inside field codes as plain text.
        FindReplaceOptions replaceOptions = new FindReplaceOptions
        {
            MatchCase = true,
            FindWholeWordsOnly = false
        };

        // DISPLAYBARCODE field stores the value inside quotes, e.g. "ABC123".
        // Replace the quoted old value with the quoted new value.
        doc.Range.Replace($"\"{oldBarcodeValue}\"", $"\"{newBarcodeValue}\"", replaceOptions);

        // After changing the field code we must update the fields so the barcode image is regenerated.
        doc.Range.UpdateFields();

        // Render the document (e.g., to PDF) and save.
        doc.Save(outputPath, SaveFormat.Pdf);
    }
}
