using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation("input.pptx");
        // Create an auxiliary presentation that will hold the slide with notes layout
        Aspose.Slides.Presentation auxPresentation = new Aspose.Slides.Presentation();

        // Clone the first slide (or any desired slide) into the auxiliary presentation
        Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[0];
        auxPresentation.Slides.InsertClone(0, sourceSlide);

        // Optionally set the slide size for the PDF page
        auxPresentation.SlideSize.SetSize(612F, 792F, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Configure PDF options to include speaker notes at the bottom of each slide
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
        {
            NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
        };

        // Save the auxiliary presentation as PDF with notes
        auxPresentation.Save("output_with_notes.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Save the original presentation before exiting (optional)
        sourcePresentation.Save("input_saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        sourcePresentation.Dispose();
        auxPresentation.Dispose();
    }
}