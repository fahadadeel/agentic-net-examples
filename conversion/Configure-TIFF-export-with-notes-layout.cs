using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTiffExport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Configure TIFF export options with notes layout
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                tiffOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions
                {
                    NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
                };

                // Save the presentation as TIFF with the configured options
                presentation.Save("output.tiff", Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}