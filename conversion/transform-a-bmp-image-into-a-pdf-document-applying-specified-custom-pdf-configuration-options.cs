using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

string inputBmpPath = @"C:\temp\input.bmp";
string outputPdfPath = @"C:\temp\output.pdf";

using (Image image = Image.Load(inputBmpPath)) // Load the BMP image
{
    // Create PDF export options
    PdfOptions pdfOptions = new PdfOptions();

    // Custom PDF configuration
    pdfOptions.KeepMetadata = true;                     // Preserve original image metadata
    pdfOptions.UseOriginalImageResolution = true;       // Use the BMP's DPI for the PDF
    pdfOptions.PageSize = new SizeF(595f, 842f);        // Set page size to A4 (points at 72 DPI)

    // Save the loaded image as a PDF using the configured options
    image.Save(outputPdfPath, pdfOptions);
}