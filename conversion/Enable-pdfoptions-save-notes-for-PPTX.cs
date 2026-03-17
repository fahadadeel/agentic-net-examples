using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the PPTX presentation
                Presentation presentation = new Presentation("input.pptx");

                // Configure PDF options to preserve notes
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
                {
                    NotesPosition = NotesPositions.BottomFull
                };

                // Save the presentation as PDF with notes
                presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during conversion
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}