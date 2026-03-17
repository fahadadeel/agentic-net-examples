using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteSpeakerNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Index of the slide whose notes we want to delete (zero‑based)
                    int slideIndex = 0;

                    // Ensure the slide index is within range
                    if (slideIndex >= 0 && slideIndex < presentation.Slides.Count)
                    {
                        // Get the notes slide manager for the target slide
                        Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[slideIndex].NotesSlideManager;
                        // Remove the notes slide
                        notesManager.RemoveNotesSlide();
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}