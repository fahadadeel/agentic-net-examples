using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source PowerPoint presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create TIFF export options
        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

        // Configure notes layout so that notes appear at the bottom of each page
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
        tiffOptions.SlidesLayoutOptions = notesOptions;

        // Optional: set image resolution (DPI)
        tiffOptions.DpiX = 200;
        tiffOptions.DpiY = 200;

        // Save the presentation as a multi‑page TIFF file with notes
        presentation.Save("output.tiff", Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

        // Release resources
        presentation.Dispose();
    }
}