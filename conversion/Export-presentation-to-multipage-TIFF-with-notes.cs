using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation file
            Presentation presentation = new Presentation("input.pptx");

            // Configure TIFF export options to include speaker notes
            TiffOptions tiffOptions = new TiffOptions();
            NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
            notesOptions.NotesPosition = NotesPositions.BottomFull;
            tiffOptions.SlidesLayoutOptions = notesOptions;

            // Save the presentation as a multi‑page TIFF image
            presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}