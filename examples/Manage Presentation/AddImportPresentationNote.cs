using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories and files
        string dataDir = "Data";
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }
        string inputPath = Path.Combine(dataDir, "source.pptx");
        string outputPath = Path.Combine(dataDir, "output_with_notes.pptx");

        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Add a notes slide to the first slide and set its text
        Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
        Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();
        notesSlide.NotesTextFrame.Text = "This is an imported note.";

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}