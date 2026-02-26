using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define directories and file paths
        string dataDir = "Data";
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.ppt");

        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Add a notes slide to the first slide and set its text
        Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
        Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();
        notesSlide.NotesTextFrame.Text = "This is a note for slide 1.";

        // Save the presentation in PPT format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Release resources
        presentation.Dispose();
    }
}