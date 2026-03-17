using System;

namespace PresentationToPdfWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the PPTX presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Create PDF export options
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                // Configure layout to include slide notes at the bottom
                Aspose.Slides.Export.NotesCommentsLayoutingOptions layoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
                layoutOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
                pdfOptions.SlidesLayoutOptions = layoutOptions;

                // Save the presentation as PDF with notes
                presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}