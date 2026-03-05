using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Create TIFF export options
        Aspose.Slides.Export.TiffOptions options = new Aspose.Slides.Export.TiffOptions();

        // Configure notes layouting options
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

        // Assign the notes layouting options to the TIFF options
        options.SlidesLayoutOptions = notesOptions;

        // Save the presentation as a TIFF file with the specified options
        pres.Save("output.tiff", Aspose.Slides.Export.SaveFormat.Tiff, options);

        // Clean up
        pres.Dispose();
    }
}