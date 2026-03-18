using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation that will be imported.
            // This demonstrates how external presentations can be brought into a new file.
            Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation("source.pptx");

            // Create a new presentation that will receive the imported slide.
            Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation();

            // Import the first slide from the source presentation into the destination.
            Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[0];
            destinationPresentation.Slides.InsertClone(0, sourceSlide);

            // Add a notes slide to the imported slide.
            Aspose.Slides.INotesSlideManager notesManager = destinationPresentation.Slides[0].NotesSlideManager;
            Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();
            notesSlide.NotesTextFrame.Text = "Notes for the imported slide.";

            // Save the resulting presentation.
            destinationPresentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose presentations explicitly (also handled by using statements if preferred).
            sourcePresentation.Dispose();
            destinationPresentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}