using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fields;

namespace BarcodeCachingExample
{
    // Custom barcode generator that caches generated images.
    public class CachedBarcodeGenerator : IBarcodeGenerator
    {
        // Cache key -> image bytes.
        private readonly Dictionary<string, byte[]> _cache = new Dictionary<string, byte[]>();

        // Optional counter to demonstrate how many times generation occurs.
        public int GenerationCount { get; private set; }

        // Generate a unique key based on all relevant barcode parameters.
        private string GetCacheKey(BarcodeParameters parameters)
        {
            // Concatenate the most important properties; adjust as needed for your scenario.
            return $"{parameters.BarcodeType}|{parameters.BarcodeValue}|{parameters.BackgroundColor}|{parameters.ForegroundColor}|{parameters.ErrorCorrectionLevel}|{parameters.ScalingFactor}|{parameters.SymbolHeight}|{parameters.SymbolRotation}|{parameters.DisplayText}|{parameters.PosCodeStyle}|{parameters.FixCheckDigit}|{parameters.CaseCodeStyle}";
        }

        // This method is called by Aspose.Words for DISPLAYBARCODE fields.
        public Stream GetBarcodeImage(BarcodeParameters parameters)
        {
            string key = GetCacheKey(parameters);

            // Return cached image if it exists.
            if (_cache.TryGetValue(key, out byte[] cachedBytes))
                return new MemoryStream(cachedBytes, writable: false);

            // Image not cached – generate it.
            byte[] imageBytes = GenerateBarcodeImage(parameters);
            _cache[key] = imageBytes; // Store for future use.

            return new MemoryStream(imageBytes, writable: false);
        }

        // This method is called by Aspose.Words for old‑fashioned BARCODE fields.
        public Stream GetOldBarcodeImage(BarcodeParameters parameters)
        {
            // Reuse the same caching logic.
            return GetBarcodeImage(parameters);
        }

        // Placeholder for real barcode generation logic.
        // Replace this with a call to a real barcode library (e.g., ZXing, Aspose.BarCode, etc.).
        private byte[] GenerateBarcodeImage(BarcodeParameters parameters)
        {
            GenerationCount++;

            // For demonstration we create a simple 1×1 pixel PNG.
            // In production you would generate the actual barcode image here.
            using (var ms = new MemoryStream())
            {
                // PNG header for an empty image (1x1 pixel, transparent).
                byte[] pngHeader = new byte[]
                {
                    0x89,0x50,0x4E,0x47,0x0D,0x0A,0x1A,0x0A,
                    0x00,0x00,0x00,0x0D,0x49,0x48,0x44,0x52,
                    0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,
                    0x08,0x06,0x00,0x00,0x00,0x1F,0x15,0xC4,
                    0x89,0x00,0x00,0x00,0x0A,0x49,0x44,0x41,
                    0x54,0x78,0x9C,0x63,0x60,0x00,0x00,0x00,
                    0x02,0x00,0x01,0xE2,0x21,0xBC,0x33,0x00,
                    0x00,0x00,0x00,0x49,0x45,0x4E,0x44,0xAE,
                    0x42,0x60,0x82
                };
                ms.Write(pngHeader, 0, pngHeader.Length);
                return ms.ToArray();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a new document.
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Assign the custom cached barcode generator.
            var cachedGenerator = new CachedBarcodeGenerator();
            doc.FieldOptions.BarcodeGenerator = cachedGenerator;

            // Insert the first DISPLAYBARCODE field.
            FieldDisplayBarcode barcode1 = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
            barcode1.BarcodeType = "QR";
            barcode1.BarcodeValue = "ABC123";
            barcode1.BackgroundColor = "0xF8BD69";
            barcode1.ForegroundColor = "0xB5413B";
            barcode1.ErrorCorrectionLevel = "3";
            barcode1.ScalingFactor = "250";
            barcode1.SymbolHeight = "1000";
            barcode1.SymbolRotation = "0";

            // Insert the same barcode again – this should hit the cache.
            builder.Writeln(); // Move to a new line.
            FieldDisplayBarcode barcode2 = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
            barcode2.BarcodeType = "QR";
            barcode2.BarcodeValue = "ABC123";
            barcode2.BackgroundColor = "0xF8BD69";
            barcode2.ForegroundColor = "0xB5413B";
            barcode2.ErrorCorrectionLevel = "3";
            barcode2.ScalingFactor = "250";
            barcode2.SymbolHeight = "1000";
            barcode2.SymbolRotation = "0";

            // Update fields to force image generation.
            doc.UpdateFields();

            // Save the document.
            doc.Save("BarcodesWithCaching.docx");

            // Output the number of actual generations – should be 1 if caching works.
            Console.WriteLine($"Barcode images generated: {cachedGenerator.GenerationCount}");
        }
    }
}
