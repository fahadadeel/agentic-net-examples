using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input PNG file and output PDF file paths
        string inputPath = "input.png";
        string outputPath = "output.pdf";

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Preserve the original image resolution in the PDF
                pdfOptions.UseOriginalImageResolution = true;

                // Save the image as a PDF document
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}