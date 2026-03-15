using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input BMP file path
        string inputPath = "input.bmp";
        // Output PDF file path
        string outputPath = "output.pdf";

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Create default PDF options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}