using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dataDir = "path_to_presentation\\";
                string inputFile = System.IO.Path.Combine(dataDir, "AccessSlides.pptx");
                string outputFile = System.IO.Path.Combine(dataDir, "RemoveNotesAtSpecificSlide_out.pptx");

                using (Presentation presentation = new Presentation(inputFile))
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Remove the notes slide associated with this slide
                    slide.NotesSlideManager.RemoveNotesSlide();

                    // Save the modified presentation
                    presentation.Save(outputFile, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}