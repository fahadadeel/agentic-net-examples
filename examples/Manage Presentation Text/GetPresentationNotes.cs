using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the notes slide manager for the first slide
            Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;

            // Add a notes slide (creates if it does not exist)
            Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();

            // Set the notes text
            notesSlide.NotesTextFrame.Text = "Your Notes";

            // Save the presentation
            presentation.Save("NotedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}