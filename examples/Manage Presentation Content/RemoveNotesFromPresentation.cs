using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "C:\\Data\\";
        string inputFile = "input.ppt";
        string outputFile = "output.ppt";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(dataDir + inputFile);

        // Remove notes from each slide
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