using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToTiffWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the source presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Configure notes layout options
                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = NotesPositions.BottomFull;

                // Set up TIFF export options with notes
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.SlidesLayoutOptions = notesOptions;

                // Save as multi‑page TIFF with embedded notes
                presentation.Save("output.tiff", Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}