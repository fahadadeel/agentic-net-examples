using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPresentationToPdfWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            System.String inputPath = "input.pptx";
            // Output PDF file path
            System.String outputPath = "output.pdf";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create PDF options and configure notes layout
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
            {
                NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
            };

            // Save the presentation as PDF with notes
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Release resources
            presentation.Dispose();
        }
    }
}