class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pdf";

        // Load the source presentation
        Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(inputPath);

        // Create an auxiliary presentation to hold the slide with notes
        Aspose.Slides.Presentation auxPresentation = new Aspose.Slides.Presentation();

        // Clone the first slide from the source presentation
        Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[0];
        auxPresentation.Slides.InsertClone(0, sourceSlide);

        // Set slide size (optional, ensures proper layout)
        auxPresentation.SlideSize.SetSize(612f, 792f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Configure PDF options to include notes at the bottom of each page
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
        {
            NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
        };

        // Save the auxiliary presentation as PDF with notes
        auxPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Release resources
        sourcePresentation.Dispose();
        auxPresentation.Dispose();
    }
}