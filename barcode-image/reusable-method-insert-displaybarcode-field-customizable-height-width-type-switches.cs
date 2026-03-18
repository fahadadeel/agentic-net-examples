using System;
using Aspose.Words;
using Aspose.Words.Fields;

namespace BarcodeDemo
{
    public static class BarcodeHelper
    {
        /// <summary>
        /// Inserts a DISPLAYBARCODE field into the document using the supplied parameters.
        /// </summary>
        /// <param name="builder">DocumentBuilder positioned where the field should be inserted.</param>
        /// <param name="value">The data to be encoded in the barcode.</param>
        /// <param name="type">Barcode type (e.g., "QR", "EAN13", "CODE39", "ITF14").</param>
        /// <param name="heightTwips">Height of the barcode symbol in TWIPS (1/1440 inch).</param>
        /// <param name="scalingFactor">Scaling factor for the symbol (percentage, 10‑1000).</param>
        /// <returns>The created FieldDisplayBarcode instance.</returns>
        public static FieldDisplayBarcode InsertDisplayBarcode(
            DocumentBuilder builder,
            string value,
            string type,
            string heightTwips,
            string scalingFactor)
        {
            // Insert an empty DISPLAYBARCODE field; the second argument (true) tells the builder to add field delimiters.
            FieldDisplayBarcode field = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);

            // Set the mandatory properties.
            field.BarcodeValue = value;
            field.BarcodeType = type;

            // Apply optional size customizations.
            field.SymbolHeight = heightTwips;      // Height in TWIPS.
            field.ScalingFactor = scalingFactor;   // Overall scaling.

            // Additional common switches can be set here if needed, e.g. colors, rotation, etc.
            // field.BackgroundColor = "0xF8BD69";
            // field.ForegroundColor = "0xB5413B";
            // field.SymbolRotation = "0";

            return field;
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a new blank document.
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Example: insert a QR code with custom height and scaling.
            BarcodeHelper.InsertDisplayBarcode(
                builder,
                value: "ABC123",
                type: "QR",
                heightTwips: "1200",   // 1200 TWIPS = 0.8333 inch.
                scalingFactor: "250"); // 250 % scaling.

            builder.Writeln(); // Move to the next line after the field.

            // Example: insert an EAN13 barcode with different size.
            BarcodeHelper.InsertDisplayBarcode(
                builder,
                value: "501234567890",
                type: "EAN13",
                heightTwips: "800",
                scalingFactor: "200");

            // Save the document.
            doc.Save("DisplayBarcodes.docx");
        }
    }
}
