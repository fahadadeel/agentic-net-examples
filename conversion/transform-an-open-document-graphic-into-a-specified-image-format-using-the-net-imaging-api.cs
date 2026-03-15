using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Input ODG file path
        string inputFile = @"C:\temp\sample.odg";

        // Desired output files
        string outputPng = @"C:\temp\sample.png";
        string outputPdf = @"C:\temp\sample.pdf";

        // Load the ODG image using the unified Image.Load method
        using (Image image = Image.Load(inputFile))
        {
            // Configure rasterization options common to both output formats
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                // Set a white background for the rasterized image
                BackgroundColor = Color.White,
                // Use the original image size as the page size
                PageSize = image.Size
            };

            // ---------- Save as PNG ----------
            PngOptions pngOptions = new PngOptions
            {
                // Attach the rasterization options so the vector ODG is rasterized correctly
                VectorRasterizationOptions = rasterOptions
            };
            // Save the image to PNG format
            image.Save(outputPng, pngOptions);

            // ---------- Save as PDF ----------
            PdfOptions pdfOptions = new PdfOptions
            {
                // Reuse the same rasterization settings for PDF output
                VectorRasterizationOptions = rasterOptions
            };
            // Save the image to PDF format
            image.Save(outputPdf, pdfOptions);
        }
    }
}