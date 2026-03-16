using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fields;

namespace BarcodeLoggingExample
{
    // Custom barcode generator that logs each generation request.
    public class LoggingBarcodeGenerator : IBarcodeGenerator
    {
        // Optional inner generator to actually produce the barcode image.
        // If null, the generator will return an empty image stream.
        private readonly IBarcodeGenerator _innerGenerator;

        public LoggingBarcodeGenerator(IBarcodeGenerator innerGenerator = null)
        {
            _innerGenerator = innerGenerator;
        }

        // Generate barcode image for DISPLAYBARCODE fields.
        public Stream GetBarcodeImage(BarcodeParameters parameters)
        {
            // Use the inner generator if supplied; otherwise create an empty stream.
            Stream imageStream = _innerGenerator?.GetBarcodeImage(parameters) ?? new MemoryStream();

            // Ensure the stream position is at the beginning for size calculation.
            if (imageStream.CanSeek)
                imageStream.Position = 0;

            // Log the field name (using BarcodeValue as a proxy) and image size in bytes.
            long imageSize = imageStream.Length;
            string logEntry = $"[{DateTime.UtcNow:O}] Field: {parameters.BarcodeValue}, ImageSize: {imageSize} bytes{Environment.NewLine}";
            File.AppendAllText("BarcodeGenerationLog.txt", logEntry);

            // Return the stream to the caller (position reset to start).
            if (imageStream.CanSeek)
                imageStream.Position = 0;

            return imageStream;
        }

        // Generate barcode image for old-fashioned BARCODE fields.
        public Stream GetOldBarcodeImage(BarcodeParameters parameters)
        {
            // Reuse the same logic as GetBarcodeImage.
            return GetBarcodeImage(parameters);
        }
    }

    class Program
    {
        static void Main()
        {
            // Load an existing document or create a new one.
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Assign the custom logging generator to the document.
            // If you have a real generator (e.g., from a third‑party library), pass it to the constructor.
            doc.FieldOptions.BarcodeGenerator = new LoggingBarcodeGenerator();

            // Example: insert a DISPLAYBARCODE field and generate its image manually.
            FieldDisplayBarcode barcodeField = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
            barcodeField.BarcodeValue = "ABC123";
            barcodeField.BarcodeType = "QR";
            barcodeField.BackgroundColor = "0xF8BD69";
            barcodeField.ForegroundColor = "0xB5413B";
            barcodeField.ErrorCorrectionLevel = "3";
            barcodeField.ScalingFactor = "250";
            barcodeField.SymbolHeight = "1000";
            barcodeField.SymbolRotation = "0";

            // Build the parameters object that the generator expects.
            BarcodeParameters parameters = new BarcodeParameters
            {
                BarcodeValue = barcodeField.BarcodeValue,
                BarcodeType = barcodeField.BarcodeType,
                BackgroundColor = barcodeField.BackgroundColor,
                ForegroundColor = barcodeField.ForegroundColor,
                ErrorCorrectionLevel = barcodeField.ErrorCorrectionLevel,
                ScalingFactor = barcodeField.ScalingFactor,
                SymbolHeight = barcodeField.SymbolHeight,
                SymbolRotation = barcodeField.SymbolRotation
            };

            // Generate the barcode image; this will also write a log entry.
            using (Stream imgStream = doc.FieldOptions.BarcodeGenerator.GetBarcodeImage(parameters))
            {
                // Insert the generated image into the document.
                imgStream.Position = 0;
                builder.InsertImage(imgStream);
            }

            // Save the document.
            doc.Save("BarcodeWithLogging.docx");
        }
    }
}
