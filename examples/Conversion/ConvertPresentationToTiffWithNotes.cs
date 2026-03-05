using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Paths to the source PPTX and the target TIFF file
        string dataDir = "C:\\Data\\";
        string inputPath = System.IO.Path.Combine(dataDir, "input.pptx");
        string outputPath = System.IO.Path.Combine(dataDir, "output.tiff");

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Configure TIFF options to include notes
        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
        tiffOptions.SlidesLayoutOptions = notesOptions;

        // Save the presentation as a multi‑page TIFF with notes
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

        // Release resources
        presentation.Dispose();
    }
}