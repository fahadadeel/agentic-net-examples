using System;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path
        string inputPath = "input.pptx";
        // Output TIFF path
        string outputPath = "output.tiff";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Add speaker notes to the first slide
        Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
        Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();
        notesSlide.NotesTextFrame.Text = "Speaker notes for slide 1";

        // Configure TIFF options to include notes
        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesLayout = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesLayout.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
        tiffOptions.SlidesLayoutOptions = notesLayout;

        // Save the presentation as TIFF with notes
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

        // Dispose the presentation
        presentation.Dispose();
    }
}