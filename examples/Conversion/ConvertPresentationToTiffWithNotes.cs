using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create TIFF export options
        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

        // Configure notes layout to include slide notes at the bottom
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
        tiffOptions.SlidesLayoutOptions = notesOptions;

        // Optional: set image resolution (DPI)
        tiffOptions.DpiX = 200U;
        tiffOptions.DpiY = 200U;

        // Save the presentation as a multi‑page TIFF file with notes
        presentation.Save("output.tiff", Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

        // Release resources
        presentation.Dispose();
    }
}