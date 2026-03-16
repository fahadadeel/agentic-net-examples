using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Saving;

namespace BarcodeRenderingControl
{
    // Custom barcode generator that returns an empty image.
    // This effectively disables barcode rendering during PDF export.
    public class NullBarcodeGenerator : IBarcodeGenerator
    {
        // Returns an empty (zero‑length) stream for the new DISPLAYBARCODE field.
        public Stream GetBarcodeImage(BarcodeParameters parameters)
        {
            // An empty stream results in no image being inserted.
            return new MemoryStream();
        }

        // Returns an empty stream for the legacy BARCODE field.
        public Stream GetOldBarcodeImage(BarcodeParameters parameters)
        {
            return new MemoryStream();
        }
    }

    class Program
    {
        static void Main()
        {
            // ---------- Create a document with barcode fields ----------
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Insert a DISPLAYBARCODE field (QR code) – this will be rendered in DOCX.
            FieldDisplayBarcode displayBarcode = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
            displayBarcode.BarcodeType = "QR";
            displayBarcode.BarcodeValue = "ABC123";
            displayBarcode.BackgroundColor = "0xF8BD69";
            displayBarcode.ForegroundColor = "0xB5413B";
            displayBarcode.ErrorCorrectionLevel = "3";
            displayBarcode.ScalingFactor = "250";
            displayBarcode.SymbolHeight = "1000";
            displayBarcode.SymbolRotation = "0";

            // Insert a legacy BARCODE field (postal barcode) – also retained in DOCX.
            FieldBarcode legacyBarcode = (FieldBarcode)builder.InsertField(FieldType.FieldBarcode, true);
            legacyBarcode.PostalAddress = "96801";
            legacyBarcode.IsUSPostalAddress = true;
            legacyBarcode.FacingIdentificationMark = "C";

            // Save the original document as DOCX – barcodes are kept as fields.
            doc.Save("Barcodes.docx");

            // ---------- Disable barcode rendering for PDF export ----------
            // Assign the custom generator that produces no image.
            doc.FieldOptions.BarcodeGenerator = new NullBarcodeGenerator();

            // Configure PDF save options (optional: keep other fields unchanged).
            PdfSaveOptions pdfOptions = new PdfSaveOptions
            {
                // Ensure fields are not updated to avoid any automatic image generation.
                UpdateFields = false
            };

            // Save to PDF – barcode fields will appear as empty placeholders.
            doc.Save("Barcodes_NoBarcodes.pdf", pdfOptions);
        }
    }
}
