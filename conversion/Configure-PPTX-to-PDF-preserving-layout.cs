using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input PowerPoint and output PDF
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure PDF conversion options
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.JpegQuality = 90;                                   // Set JPEG quality
            pdfOptions.SaveMetafilesAsPng = true;                          // Convert metafiles to PNG
            pdfOptions.TextCompression = PdfTextCompression.Flate;        // Use Flate compression for text
            pdfOptions.Compliance = PdfCompliance.Pdf15;                   // Set PDF compliance level
            pdfOptions.ShowHiddenSlides = true;                            // Include hidden slides

            // Configure slide layout (e.g., handout 4 horizontal)
            pdfOptions.SlidesLayoutOptions = new HandoutLayoutingOptions
            {
                Handout = HandoutType.Handouts4Horizontal
            };

            // Save the presentation as PDF with the configured options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Clean up resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}