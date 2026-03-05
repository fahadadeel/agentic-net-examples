using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConfigureJpegOptionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            System.String inputPath = "input.pptx";
            // Output PDF file path
            System.String outputPath = "output.pdf";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create PDF options and configure JPEG quality
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.JpegQuality = 80; // JPEG quality (0-100)
            pdfOptions.SaveMetafilesAsPng = true;
            pdfOptions.TextCompression = Aspose.Slides.Export.PdfTextCompression.Flate;
            pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.Pdf15;

            // Configure notes layouting options (optional)
            Aspose.Slides.Export.NotesCommentsLayoutingOptions layoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            layoutOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
            pdfOptions.SlidesLayoutOptions = layoutOptions;

            // Save the presentation as PDF with the configured options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}