using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the source presentation
                Presentation presentation = new Presentation("input.pptx");

                // Create an auxiliary presentation to hold the slide with notes
                using (Presentation auxPresentation = new Presentation())
                {
                    // Clone the first slide (including its notes)
                    ISlide slide = presentation.Slides[0];
                    auxPresentation.Slides.InsertClone(0, slide);

                    // Set the slide size for the PDF output
                    auxPresentation.SlideSize.SetSize(612F, 792F, SlideSizeScaleType.EnsureFit);

                    // Configure PDF options to include speaker notes at the bottom
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions()
                    {
                        NotesPosition = NotesPositions.BottomFull
                    };

                    // Save the auxiliary presentation as PDF with notes
                    auxPresentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }

                // Clean up the original presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}