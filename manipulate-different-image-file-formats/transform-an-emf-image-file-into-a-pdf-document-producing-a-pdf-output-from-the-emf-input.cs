using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class EmfToPdfConverter
{
    static void Main()
    {
        // Path to the source EMF file
        string inputFile = @"C:\Temp\input.emf";

        // Desired path for the resulting PDF file
        string outputFile = @"C:\Temp\output.pdf";

        // Load the EMF image using the unified Image.Load method
        using (Image emfImage = Image.Load(inputFile))
        {
            // Create PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Configure vector rasterization so the EMF is rendered correctly in the PDF
            pdfOptions.VectorRasterizationOptions = new EmfRasterizationOptions
            {
                // Use the original image size as the PDF page size
                PageSize = emfImage.Size
            };

            // Save the EMF image as a PDF document
            emfImage.Save(outputFile, pdfOptions);
        }
    }
}