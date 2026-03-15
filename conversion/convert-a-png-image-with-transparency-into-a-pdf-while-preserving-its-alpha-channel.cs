using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG file (with transparency) and output PDF file paths.
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output.pdf";

        // Load the PNG image. Aspose.Imaging preserves the alpha channel automatically.
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options. Preserve the original image resolution.
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.UseOriginalImageResolution = true;

                // Save the image as a PDF while keeping the transparency.
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}