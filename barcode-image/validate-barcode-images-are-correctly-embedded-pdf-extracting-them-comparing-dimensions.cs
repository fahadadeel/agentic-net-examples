using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;

class Program
{
    static void Main()
    {
        // Path to the PDF that contains barcode images.
        string pdfPath = "Barcodes.pdf";

        // Expected dimensions for each barcode image (in pixels).
        // The key is the zero‑based index of the barcode image in the document.
        var expectedSizes = new Dictionary<int, Size>
        {
            { 0, new Size(200, 200) }, // Example: first barcode expected 200×200
            { 1, new Size(300, 150) }  // Example: second barcode expected 300×150
            // Add more entries as needed.
        };

        ValidateBarcodes(pdfPath, expectedSizes);
    }

    /// <summary>
    /// Loads a PDF, extracts all embedded images (barcode images), and compares their dimensions
    /// with the expected sizes supplied in <paramref name="expectedSizes"/>.
    /// </summary>
    /// <param name="pdfPath">Path to the PDF file.</param>
    /// <param name="expectedSizes">Dictionary mapping image index to expected Size.</param>
    static void ValidateBarcodes(string pdfPath, Dictionary<int, Size> expectedSizes)
    {
        // Load the PDF document using Aspose.Words.
        Document doc = new Document(pdfPath);

        // Retrieve all Shape nodes – these represent images in the document.
        NodeCollection shapeNodes = doc.GetChildNodes(NodeType.Shape, true);

        int barcodeIndex = 0;

        foreach (Shape shape in shapeNodes)
        {
            // Process only shapes that actually contain an image.
            if (!shape.HasImage)
                continue;

            // -------------------------------------------------------------------
            // Get the image size in points (1 point = 1/72 inch).
            // Aspose.Words exposes it via ImageData.ImageSize.
            // -------------------------------------------------------------------
            ImageSize sizeInPoints = shape.ImageData.ImageSize;

            // Convert points to pixels assuming a standard screen resolution of 96 DPI.
            // pixels = points * (dpi / 72)
            const float dpi = 96f;
            int actualWidthPx = (int)Math.Round(sizeInPoints.WidthPoints * dpi / 72f);
            int actualHeightPx = (int)Math.Round(sizeInPoints.HeightPoints * dpi / 72f);
            Size actualSize = new Size(actualWidthPx, actualHeightPx);

            // Check if we have an expected size for this barcode index.
            if (expectedSizes.TryGetValue(barcodeIndex, out Size expectedSize))
            {
                bool matches = actualSize.Width == expectedSize.Width && actualSize.Height == expectedSize.Height;
                Console.WriteLine($"Barcode #{barcodeIndex}: {(matches ? "PASS" : "FAIL")} – " +
                                  $"Actual: {actualSize.Width}x{actualSize.Height}, " +
                                  $"Expected: {expectedSize.Width}x{expectedSize.Height}");
            }
            else
            {
                Console.WriteLine($"Barcode #{barcodeIndex}: No expected size defined – " +
                                  $"Actual size: {actualSize.Width}x{actualSize.Height}");
            }

            barcodeIndex++;
        }

        // If no images were found, inform the user.
        if (barcodeIndex == 0)
        {
            Console.WriteLine("No barcode images were found in the PDF.");
        }
    }
}
