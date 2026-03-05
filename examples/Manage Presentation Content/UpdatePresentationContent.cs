using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation (contains one empty slide)
        using (var presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            var slide = presentation.Slides[0];

            // Add a rectangle shape with some text
            var shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50, 50, 400, 200);
            shape.TextFrame.Text = "Hello Aspose.Slides";

            // Add notes to the slide
            var notesManager = slide.NotesSlideManager;
            var notesSlide = notesManager.AddNotesSlide();
            notesSlide.NotesTextFrame.Text = "These are speaker notes.";

            // Save the presentation in PPT format
            presentation.Save("LivePresentation.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}