using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PNG file path and output PDF file path
            string inputPath = "input.png";
            string outputPath = "output.pdf";

            // Verify that the input PNG file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the PNG image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Create PDF options; additional settings (e.g., page size, resolution) can be configured here
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Save the loaded image as a PDF document
                    image.Save(outputPath, pdfOptions);
                }
            }

            Console.WriteLine("PNG to PDF conversion completed successfully.");
        }
    }
}