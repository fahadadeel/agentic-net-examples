using System;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation("input.pptx");

        // Create a new presentation for notes export
        Aspose.Slides.Presentation notesPresentation = new Aspose.Slides.Presentation();

        // Clone all slides into the new presentation
        for (int i = 0; i < sourcePresentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[i];
            notesPresentation.Slides.InsertClone(i, sourceSlide);
        }

        // Set slide size (optional)
        notesPresentation.SlideSize.SetSize(612F, 792F, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Configure PDF options to include notes
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
        {
            NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
        };

        // Save the presentation as PDF with notes
        notesPresentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Dispose resources
        sourcePresentation.Dispose();
        notesPresentation.Dispose();
    }
}