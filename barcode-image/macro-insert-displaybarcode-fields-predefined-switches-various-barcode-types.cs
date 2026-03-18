using System;
using Aspose.Words;
using Aspose.Words.Fields;

namespace DisplayBarcodeMacro
{
    class Program
    {
        static void Main()
        {
            // Create a new blank document.
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Insert a QR code with custom colors and scaling.
            InsertDisplayBarcode(builder,
                barcodeValue: "ABC123",
                barcodeType: "QR",
                backgroundColor: "0xF8BD69",
                foregroundColor: "0xB5413B",
                errorCorrectionLevel: "3",
                scalingFactor: "250",
                symbolHeight: "1000",
                symbolRotation: "0");

            builder.Writeln();

            // Insert an EAN13 barcode with the numeric value displayed below the bars.
            InsertDisplayBarcode(builder,
                barcodeValue: "501234567890",
                barcodeType: "EAN13",
                displayText: true,
                posCodeStyle: "CASE",
                fixCheckDigit: true);

            builder.Writeln();

            // Insert a CODE39 barcode with start/stop characters.
            InsertDisplayBarcode(builder,
                barcodeValue: "12345ABCDE",
                barcodeType: "CODE39",
                addStartStopChar: true);

            builder.Writeln();

            // Insert an ITF14 barcode with a specified case code style.
            InsertDisplayBarcode(builder,
                barcodeValue: "09312345678907",
                barcodeType: "ITF14",
                caseCodeStyle: "STD");

            // Save the document.
            doc.Save("DisplayBarcodes.docx");
        }

        /// <summary>
        /// Inserts a DISPLAYBARCODE field and sets the requested switches.
        /// Only the switches that are supplied (non‑null) are applied.
        /// </summary>
        static void InsertDisplayBarcode(DocumentBuilder builder,
            string barcodeValue,
            string barcodeType,
            string backgroundColor = null,
            string foregroundColor = null,
            string errorCorrectionLevel = null,
            string scalingFactor = null,
            string symbolHeight = null,
            string symbolRotation = null,
            bool? displayText = null,
            string posCodeStyle = null,
            bool? fixCheckDigit = null,
            bool? addStartStopChar = null,
            string caseCodeStyle = null)
        {
            // Insert an empty DISPLAYBARCODE field; the second argument (true) tells the builder to add the field separator.
            FieldDisplayBarcode field = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);

            // Required properties.
            field.BarcodeValue = barcodeValue;
            field.BarcodeType = barcodeType;

            // Optional switches – set only when a value is provided.
            if (backgroundColor != null) field.BackgroundColor = backgroundColor;
            if (foregroundColor != null) field.ForegroundColor = foregroundColor;
            if (errorCorrectionLevel != null) field.ErrorCorrectionLevel = errorCorrectionLevel;
            if (scalingFactor != null) field.ScalingFactor = scalingFactor;
            if (symbolHeight != null) field.SymbolHeight = symbolHeight;
            if (symbolRotation != null) field.SymbolRotation = symbolRotation;
            if (displayText.HasValue) field.DisplayText = displayText.Value;
            if (posCodeStyle != null) field.PosCodeStyle = posCodeStyle;
            if (fixCheckDigit.HasValue) field.FixCheckDigit = fixCheckDigit.Value;
            if (addStartStopChar.HasValue) field.AddStartStopChar = addStartStopChar.Value;
            if (caseCodeStyle != null) field.CaseCodeStyle = caseCodeStyle;
        }
    }
}
