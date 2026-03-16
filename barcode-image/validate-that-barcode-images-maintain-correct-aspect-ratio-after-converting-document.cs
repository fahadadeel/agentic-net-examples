using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;
using Aspose.Words.Loading;
using Aspose.Words.Drawing; // <-- Added for Shape class

class BarcodeAspectRatioValidator
{
    // Tolerance for floating‑point comparison of aspect ratios.
    private const double AspectRatioTolerance = 0.001;

    static void Main()
    {
        // -----------------------------------------------------------------
        // 1. Load the source DOCX that contains barcode images.
        // -----------------------------------------------------------------
        // (Replace the path with the actual location of your document.)
        Document doc = new Document(@"C:\Docs\Barcodes.docx");

        // -----------------------------------------------------------------
        // 2. Record the aspect ratios of all image shapes in the DOCX.
        // -----------------------------------------------------------------
        List<double> docAspectRatios = GetImageAspectRatios(doc);

        // -----------------------------------------------------------------
        // 3. Save the document to PDF using PdfSaveOptions.
        // -----------------------------------------------------------------
        PdfSaveOptions pdfSaveOptions = new PdfSaveOptions
        {
            // Ensure that the conversion does not alter image scaling.
            // The default settings already keep the original dimensions,
            // but we explicitly disable any down‑sampling that could affect size.
            DownsampleOptions = { DownsampleImages = false }
        };

        string pdfPath = @"C:\Docs\Barcodes.pdf";
        doc.Save(pdfPath, pdfSaveOptions);

        // -----------------------------------------------------------------
        // 4. Load the generated PDF back into a Document object.
        // -----------------------------------------------------------------
        PdfLoadOptions pdfLoadOptions = new PdfLoadOptions
        {
            // Load the PDF without skipping images so we can inspect them.
            SkipPdfImages = false
        };

        Document pdfDoc = new Document(pdfPath, pdfLoadOptions);

        // -----------------------------------------------------------------
        // 5. Record the aspect ratios of all image shapes in the PDF.
        // -----------------------------------------------------------------
        List<double> pdfAspectRatios = GetImageAspectRatios(pdfDoc);

        // -----------------------------------------------------------------
        // 6. Validate that the number of images matches and each aspect ratio
        //    is preserved within the defined tolerance.
        // -----------------------------------------------------------------
        if (docAspectRatios.Count != pdfAspectRatios.Count)
        {
            Console.WriteLine("Image count mismatch: DOCX has {0}, PDF has {1}.",
                docAspectRatios.Count, pdfAspectRatios.Count);
            return;
        }

        for (int i = 0; i < docAspectRatios.Count; i++)
        {
            double docRatio = docAspectRatios[i];
            double pdfRatio = pdfAspectRatios[i];
            double diff = Math.Abs(docRatio - pdfRatio);

            if (diff > AspectRatioTolerance)
            {
                Console.WriteLine($"Image {i + 1}: aspect ratio changed (DOCX={docRatio:F4}, PDF={pdfRatio:F4}).");
            }
            else
            {
                Console.WriteLine($"Image {i + 1}: aspect ratio preserved (ratio={docRatio:F4}).");
            }
        }
    }

    /// <summary>
    /// Retrieves the aspect ratios (Width / Height) of all image shapes in the given document.
    /// </summary>
    private static List<double> GetImageAspectRatios(Document document)
    {
        List<double> ratios = new List<double>();

        // Collect all Shape nodes that contain images.
        NodeCollection shapes = document.GetChildNodes(NodeType.Shape, true);
        foreach (Shape shape in shapes)
        {
            if (shape.IsImage)
            {
                // Width and Height are stored in points (1 point = 1/72 inch).
                // Convert to double for ratio calculation.
                double width = shape.Width;
                double height = shape.Height;

                // Guard against zero height to avoid division by zero.
                if (height != 0)
                {
                    ratios.Add(width / height);
                }
            }
        }

        return ratios;
    }
}
