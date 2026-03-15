using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source APNG file
        string inputApngPath = "input.apng";

        // Desired output PDF file path
        string outputPdfPath = "output.pdf";

        // Load the APNG image using the provided Image.Load method
        using (Image apngImage = Image.Load(inputApngPath))
        {
            // Save the loaded image as PDF.
            // PdfOptions is the appropriate save options class for PDF format.
            // This uses the Image.Save(string, ImageOptionsBase) rule.
            apngImage.Save(outputPdfPath, new PdfOptions());
        }
    }
}