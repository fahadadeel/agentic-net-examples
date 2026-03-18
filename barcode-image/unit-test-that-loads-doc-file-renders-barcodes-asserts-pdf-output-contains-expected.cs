using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Loading;
using Aspose.Words.Saving;

namespace Aspose.Words.Tests
{
    class Program
    {
        // Paths used in the test – adjust as needed for your environment.
        private const string MyDir = @"..\..\..\TestData\";
        private const string ArtifactsDir = @"..\..\..\Artifacts\";

        static void Main()
        {
            try
            {
                LoadDocRenderBarcodeAndVerifyPdfContainsImages();
                Console.WriteLine("Test passed.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Test failed: {ex.Message}");
                Environment.Exit(1);
            }
        }

        private static void LoadDocRenderBarcodeAndVerifyPdfContainsImages()
        {
            // 1. Load an existing DOC file.
            string docPath = Path.Combine(MyDir, "BarcodeTemplate.doc");
            Document doc = new Document(docPath);

            // 2. Insert a DISPLAYBARCODE field (QR code) using DocumentBuilder.
            DocumentBuilder builder = new DocumentBuilder(doc);
            FieldDisplayBarcode barcodeField = (FieldDisplayBarcode)builder.InsertField(FieldType.FieldDisplayBarcode, true);
            barcodeField.BarcodeType = "QR";
            barcodeField.BarcodeValue = "ABC123";
            barcodeField.BackgroundColor = "0xF8BD69";
            barcodeField.ForegroundColor = "0xB5413B";
            barcodeField.ErrorCorrectionLevel = "3";
            barcodeField.ScalingFactor = "250";
            barcodeField.SymbolHeight = "1000";
            barcodeField.SymbolRotation = "0";

            // 3. Update fields so that the barcode image is generated.
            doc.UpdateFields();

            // 4. Save the document as PDF.
            string pdfPath = Path.Combine(ArtifactsDir, "RenderedBarcode.pdf");
            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            doc.Save(pdfPath, pdfSaveOptions);

            // 5. Load the generated PDF without skipping images.
            PdfLoadOptions loadOptionsWithImages = new PdfLoadOptions { SkipPdfImages = false };
            Document pdfDocWithImages = new Document(pdfPath, loadOptionsWithImages);
            var shapesWithImages = pdfDocWithImages.GetChildNodes(NodeType.Shape, true);
            if (shapesWithImages.Count <= 0)
                throw new Exception("PDF should contain at least one image (the barcode).");

            // 6. Load the same PDF while skipping images to demonstrate the option works.
            PdfLoadOptions loadOptionsSkipImages = new PdfLoadOptions { SkipPdfImages = true };
            Document pdfDocWithoutImages = new Document(pdfPath, loadOptionsSkipImages);
            var shapesWithoutImages = pdfDocWithoutImages.GetChildNodes(NodeType.Shape, true);
            if (shapesWithoutImages.Count != 0)
                throw new Exception("PDF loaded with SkipPdfImages should contain no image shapes.");
        }
    }
}
