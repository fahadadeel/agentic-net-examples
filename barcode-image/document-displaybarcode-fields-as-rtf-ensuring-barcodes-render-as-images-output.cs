using System;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Saving;

namespace DisplayBarcodeRtfExample
{
    class Program
    {
        static void Main()
        {
            // Create a new empty document.
            Document doc = new Document();

            // Use DocumentBuilder to insert a DISPLAYBARCODE field.
            DocumentBuilder builder = new DocumentBuilder(doc);
            FieldDisplayBarcode barcodeField = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);

            // Configure the barcode – this example creates a QR code.
            barcodeField.BarcodeType = "QR";
            barcodeField.BarcodeValue = "12345ABC";
            barcodeField.BackgroundColor = "0xF8BD69";   // Light orange background.
            barcodeField.ForegroundColor = "0xB5413B";   // Dark red foreground.
            barcodeField.ErrorCorrectionLevel = "3";     // High error correction.
            barcodeField.ScalingFactor = "250";          // 250 % scaling.
            barcodeField.SymbolHeight = "1000";          // Height in TWIPS.
            barcodeField.SymbolRotation = "0";           // No rotation.

            // Prepare RTF save options.
            RtfSaveOptions rtfOptions = new RtfSaveOptions
            {
                // Ensure fields are updated so the barcode is rendered as an image.
                UpdateFields = true,

                // Optional: keep original image formats (false) – not required for barcodes.
                SaveImagesAsWmf = false
            };

            // Save the document as RTF. The DISPLAYBARCODE field will be rendered as an image.
            doc.Save("DisplayBarcode.rtf", rtfOptions);
        }
    }
}
