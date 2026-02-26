using System;

namespace AsposeSlidesPdfWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the existing presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Create PDF export options
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                // Configure the layout to include speaker notes at the bottom of each slide
                pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
                {
                    NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
                };

                // Save the presentation as PDF with the specified options
                presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
    }
}