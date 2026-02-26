using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the directory containing the presentation files
            string dataDir = @"C:\Data\Presentations";

            // Ensure the directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Input and output file paths
            string inputPath = Path.Combine(dataDir, "source.pptx");
            string outputPath = Path.Combine(dataDir, "source_with_notes.pptx");

            // Load the existing presentation
            Presentation presentation = new Presentation(inputPath);

            // Access the notes slide manager for the first slide
            INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;

            // Add a notes slide and set its text
            INotesSlide notesSlide = notesManager.AddNotesSlide();
            notesSlide.NotesTextFrame.Text = "This is an imported note.";

            // Save the presentation with the added notes
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}