using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToTiffWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string tiffOutputPath = "output.tiff";
                string presentationOutputPath = "saved_output.pptx";

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
                tiffOptions.SlidesLayoutOptions = notesOptions;

                presentation.Save(tiffOutputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

                // Save the original presentation before exiting
                presentation.Save(presentationOutputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}