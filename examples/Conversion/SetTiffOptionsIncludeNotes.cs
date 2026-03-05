using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        var inputPath = "input.pptx";
        // Path for the resulting TIFF file
        var outputPath = "output.tiff";

        // Load the presentation
        using (var presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Create TIFF export options
            var tiffOptions = new Aspose.Slides.Export.TiffOptions();

            // Configure notes layout to include notes in the exported TIFF
            var notesLayout = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            notesLayout.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

            // Assign the notes layout to the TIFF options
            tiffOptions.SlidesLayoutOptions = notesLayout;

            // Save the presentation as TIFF with the specified options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
        }
    }
}