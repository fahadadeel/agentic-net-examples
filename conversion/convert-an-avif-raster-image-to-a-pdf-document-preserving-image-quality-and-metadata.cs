using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input AVIF file path
        string inputPath = "input.avif";
        // Output PDF file path
        string outputPath = "output.pdf";

        // Load the AVIF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options to keep original metadata
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.KeepMetadata = true;

                // Save the image as a PDF document preserving quality and metadata
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}