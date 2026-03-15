using System;
using System.IO;
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
            // Configure PDF options to keep original metadata and resolution
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.KeepMetadata = true;
                pdfOptions.UseOriginalImageResolution = true;

                // Save the image as PDF preserving fidelity and metadata
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}