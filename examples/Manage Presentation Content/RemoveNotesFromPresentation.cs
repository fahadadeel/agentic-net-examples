using System;

class Program
{
    static void Main()
    {
        // Define the directory and file names
        string dataDir = "C:\\Data\\";
        string inputFile = "input.ppt";
        string outputFile = "output.ppt";

        // Load the presentation from the input file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(dataDir + inputFile);

        // Iterate through all slides and remove their notes
        for (int index = 0; index < presentation.Slides.Count; index++)
        {
            Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[index].NotesSlideManager;
            notesManager.RemoveNotesSlide();
        }

        // Save the modified presentation in PPT format
        presentation.Save(dataDir + outputFile, Aspose.Slides.Export.SaveFormat.Ppt);

        // Release resources
        presentation.Dispose();
    }
}