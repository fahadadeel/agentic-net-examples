using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class CmxToPdfConverter
{
    static void Main()
    {
        // Path to the source CMX file
        string inputCmxPath = @"C:\Temp\sample.cmx";

        // Desired output PDF file path
        string outputPdfPath = @"C:\Temp\sample.pdf";

        // Load the CMX image using Aspose.Imaging unified loader
        using (Image cmxImage = Image.Load(inputCmxPath))
        {
            // Prepare PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Configure rasterization options specific for CMX format
            CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
            {
                // Render text as single-bit per pixel for crisp output
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,

                // No smoothing to preserve original vector quality
                SmoothingMode = SmoothingMode.None,

                // Positioning defined by the document itself
                Positioning = PositioningTypes.DefinedByDocument
            };

            // Assign rasterization options to the PDF options
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the loaded CMX image as a PDF document
            cmxImage.Save(outputPdfPath, pdfOptions);
        }
    }
}