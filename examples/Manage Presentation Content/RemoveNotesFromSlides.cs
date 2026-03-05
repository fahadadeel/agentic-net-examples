using System;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through each slide and remove its notes slide
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
            notesManager.RemoveNotesSlide();
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}