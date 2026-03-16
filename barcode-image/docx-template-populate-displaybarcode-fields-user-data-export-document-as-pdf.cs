using System;
using Aspose.Words;
using Aspose.Words.Reporting;
using Aspose.Words.Saving;

namespace BarcodeReport
{
    // POCO class that represents the data source for the template.
    // The property names must match the placeholders used inside the DISPLAYBARCODE fields.
    public class BarcodeInfo
    {
        public string ProductCode { get; set; }   // Example: EAN13 barcode value
        public string QRCode { get; set; }        // Example: QR code value
    }

    class Program
    {
        static void Main()
        {
            // Path to the DOCX template that already contains DISPLAYBARCODE fields.
            const string templatePath = @"C:\Templates\BarcodeTemplate.docx";

            // Load the template document.
            Document doc = new Document(templatePath);

            // Create an instance of the data source with the values that should appear in the barcodes.
            var data = new BarcodeInfo
            {
                ProductCode = "501234567890", // EAN13 barcode value
                QRCode = "ABC123"             // QR code value
            };

            // Populate the template using the ReportingEngine.
            // The engine replaces the placeholders in the template with the values from the data object.
            ReportingEngine engine = new ReportingEngine();
            engine.BuildReport(doc, data);

            // Export the populated document to PDF.
            const string pdfPath = @"C:\Output\BarcodeReport.pdf";
            doc.Save(pdfPath, SaveFormat.Pdf);
        }
    }
}
