using System;
using System.Collections.Generic;
using Aspose.Words;
using Aspose.Words.Fields;

class ReplaceDisplayBarcodePlaceholder
{
    static void Main()
    {
        // Load an existing document that contains a DISPLAYBARCODE field with a placeholder value.
        Document doc = new Document("TemplateWithPlaceholder.docx");

        // Define dynamic values that will replace the placeholder.
        // The key is the placeholder text, the value is the actual barcode data.
        var replacements = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "PLACEHOLDER", "ABC123" },
            { "ANOTHER_PLACEHOLDER", "DEF456" }
        };

        // Iterate through all fields in the document.
        foreach (Field field in doc.Range.Fields)
        {
            // We are interested only in DISPLAYBARCODE fields.
            if (field.Type != FieldType.FieldDisplayBarcode)
                continue;

            // Cast to the specific field type to access its properties.
            FieldDisplayBarcode barcodeField = (FieldDisplayBarcode)field;

            // The current barcode value may be a placeholder.
            string currentValue = barcodeField.BarcodeValue;

            // If the current value matches one of our placeholders, replace it.
            if (replacements.TryGetValue(currentValue, out string newValue))
            {
                // Set the new barcode value.
                barcodeField.BarcodeValue = newValue;

                // Mark the field as dirty so that it will be recalculated.
                barcodeField.IsDirty = true;

                // Update the field to generate the new barcode image.
                barcodeField.Update();
            }
        }

        // Save the modified document.
        doc.Save("ResultWithDynamicBarcodes.docx");
    }
}
