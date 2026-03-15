using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class PngToPdfConverter
{
    static void Main()
    {
        // Path to the source PNG image
        string pngPath = @"C:\Images\source.png";

        // Desired output PDF file path
        string pdfPath = @"C:\Images\output.pdf";

        // Load the PNG raster image using Aspose.Imaging's lifecycle method
        using (Image pngImage = Image.Load(pngPath))
        {
            // Preserve the original resolution of the PNG image
            // (Aspose.Imaging retains resolution on save by default,
            //  but you can explicitly set it if needed.)
            // pngImage.SetResolution(pngImage.HorizontalResolution, pngImage.VerticalResolution);

            // Save the loaded image as a PDF document while keeping fidelity.
            // PdfOptions is the appropriate save options class for PDF output.
            pngImage.Save(pdfPath, new PdfOptions());
        }
    }
}