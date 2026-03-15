using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToPdfConverter
{
    static void Main()
    {
        // Path to the source WebP image
        string sourcePath = @"C:\Temp\input.webp";

        // Desired output PDF file path
        string outputPath = @"C:\Temp\output.pdf";

        // Load the WebP image using the provided constructor rule
        using (WebPImage webPImage = new WebPImage(sourcePath))
        {
            // Save the image as PDF using the generic Save method with PdfOptions.
            // PdfOptions ensures the image is embedded in a PDF document with high fidelity.
            webPImage.Save(outputPath, new PdfOptions());
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}