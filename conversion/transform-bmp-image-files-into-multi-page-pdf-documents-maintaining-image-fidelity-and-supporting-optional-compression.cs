using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Folder containing BMP files
        string inputFolder = @"C:\Images\BmpFiles";
        // Output PDF file path
        string outputPdf = @"C:\Images\Combined.pdf";

        // Get all BMP file paths
        string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

        if (bmpFiles.Length == 0)
        {
            Console.WriteLine("No BMP files found in the specified folder.");
            return;
        }

        // Create a multipage image from the BMP files
        using (Image multipageImage = Image.Create(bmpFiles))
        {
            // Configure PDF export options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Optional: set image compression for PDF pages
                pdfOptions.ImageCompression = PdfImageCompressionOptions.Flate;

                // Save the multipage image as a PDF document
                multipageImage.Save(outputPdf, pdfOptions);
            }
        }

        Console.WriteLine("PDF document created successfully at: " + outputPdf);
    }
}