using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Determine input and output file paths.
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";
        string outputPath = args.Length > 1 ? args[1] : "output.pdf";

        // Load the JPEG image.
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options.
            PdfOptions pdfOptions = new PdfOptions
            {
                // Preserve original metadata if present.
                KeepMetadata = true,
                // Use the original image resolution for the PDF page.
                UseOriginalImageResolution = true
            };

            // Save the image as a PDF document.
            image.Save(outputPath, pdfOptions);
        }
    }
}