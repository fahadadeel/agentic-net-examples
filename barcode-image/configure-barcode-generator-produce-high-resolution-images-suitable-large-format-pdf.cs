using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Saving;

class HighResolutionBarcodePdf
{
    static void Main()
    {
        // Create a new empty Word document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Assign a custom barcode generator (implementation not shown).
        // In a real scenario replace CustomBarcodeGenerator with your own class that implements IBarcodeGenerator.
        doc.FieldOptions.BarcodeGenerator = new CustomBarcodeGenerator();

        // Configure barcode parameters for a high‑resolution QR code.
        BarcodeParameters barcodeParams = new BarcodeParameters
        {
            BarcodeType = "QR",
            BarcodeValue = "HIGHRES123",
            // Use a large scaling factor (max 1000) to increase pixel density.
            ScalingFactor = "1000",
            // Increase symbol height (value is in twips; 1 inch = 1440 twips).
            // Example: 5 inches high → 5 * 1440 = 7200 twips.
            SymbolHeight = "7200",
            // Optional visual tweaks.
            BackgroundColor = "0xFFFFFF",
            ForegroundColor = "0x000000",
            ErrorCorrectionLevel = "3",
            SymbolRotation = "0"
        };

        // Generate the barcode image and insert it into the document.
        using (Stream imgStream = doc.FieldOptions.BarcodeGenerator.GetBarcodeImage(barcodeParams))
        {
            // Reset stream position before inserting.
            imgStream.Position = 0;
            builder.InsertImage(imgStream);
        }

        // Prepare PDF save options for high‑quality output.
        PdfSaveOptions pdfOptions = new PdfSaveOptions
        {
            // Use high‑quality (slow) rendering algorithms.
            UseHighQualityRendering = true,
            // Prevent automatic down‑sampling of images (keep original resolution).
            DownsampleOptions = { DownsampleImages = false }
        };

        // Save the document as a PDF with the configured options.
        doc.Save("HighResolutionBarcode.pdf", pdfOptions);
    }
}

// Placeholder for a user‑implemented barcode generator.
// Replace with an actual implementation that returns a high‑resolution image.
class CustomBarcodeGenerator : IBarcodeGenerator
{
    public Stream GetBarcodeImage(BarcodeParameters parameters)
    {
        // For demonstration purposes, return an empty memory stream.
        // In practice, generate the barcode image according to the parameters.
        return new MemoryStream();
    }

    public Stream GetOldBarcodeImage(BarcodeParameters parameters)
    {
        // Not used in this example.
        return new MemoryStream();
    }
}
