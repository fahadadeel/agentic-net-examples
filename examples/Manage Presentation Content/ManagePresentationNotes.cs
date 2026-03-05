using System;

namespace ManagePresentationNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            string outDir = "Output";
            if (!System.IO.Directory.Exists(outDir))
                System.IO.Directory.CreateDirectory(outDir);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a notes slide to the first slide
            Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.AddNotesSlide();

            // Set the notes text
            notesSlide.NotesTextFrame.Text = "These are the speaker notes.";

            // Save the presentation in PPT format
            string outPath = System.IO.Path.Combine(outDir, "PresentationWithNotes.ppt");
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}