using System;

class Program
{
    static void Main(string[] args)
    {
        // Verify command‑line arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: ConvertToPdfWithNotes <input-ppt-or-pptx> <output-pdf>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the source presentation (PPT or PPTX)
        using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Create a new presentation that will hold slides with notes layout
            using (Aspose.Slides.Presentation notesPresentation = new Aspose.Slides.Presentation())
            {
                // Clone each slide from the source into the notes presentation
                for (int i = 0; i < sourcePresentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[i];
                    notesPresentation.Slides.InsertClone(i, sourceSlide);
                }

                // Set slide size to standard PDF page size (8.5" x 11" = 612pt x 792pt)
                notesPresentation.SlideSize.SetSize(612F, 792F, Aspose.Slides.SlideSizeScaleType.EnsureFit);

                // Configure PDF options to include notes at the bottom of each page
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
                {
                    NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
                };

                // Save the presentation as PDF with notes
                notesPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
    }
}