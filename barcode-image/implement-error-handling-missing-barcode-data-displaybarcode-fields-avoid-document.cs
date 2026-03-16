using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fields;

class DisplayBarcodeHandler
{
    static void Main()
    {
        // Path to the source document that may contain DISPLAYBARCODE fields with missing data.
        string inputPath = @"C:\Docs\Input.docx";

        // Path where the processed document will be saved.
        string outputPath = @"C:\Docs\Output.docx";

        // Load the document using the provided lifecycle rule.
        Document doc = new Document(inputPath);

        // Iterate through all fields in the document.
        foreach (Field field in doc.Range.Fields)
        {
            // Process only DISPLAYBARCODE fields.
            if (field.Type == FieldType.FieldDisplayBarcode)
            {
                FieldDisplayBarcode barcodeField = (FieldDisplayBarcode)field;

                // If the barcode value is null, empty, or whitespace, replace it with a placeholder.
                if (string.IsNullOrWhiteSpace(barcodeField.BarcodeValue))
                {
                    // Setting a non‑empty value prevents save‑time exceptions caused by missing data.
                    barcodeField.BarcodeValue = "N/A";
                }
            }
        }

        // Save the document using the provided lifecycle rule.
        // Wrap the save operation in a try/catch to handle any unexpected errors gracefully.
        try
        {
            doc.Save(outputPath);
            Console.WriteLine("Document saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving document: {ex.Message}");
        }
    }
}
