using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Path to the source presentation file
        string sourcePath = "input.pptx";
        // Path to the output presentation file
        string outputPath = "output_without_notes.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Iterate through all slides in the presentation
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                // Get the notes slide manager for the current slide
                Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
                // Remove the notes slide (if it exists)
                notesManager.RemoveNotesSlide();
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}