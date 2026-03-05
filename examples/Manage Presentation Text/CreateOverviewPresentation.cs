using System;

class Program
{
    static void Main()
    {
        // Create a new presentation with one empty slide
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first (and only) slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape that will serve as a title placeholder
        Aspose.Slides.IAutoShape titleShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, // Shape type
            50,    // X position
            50,    // Y position
            600,   // Width
            100    // Height
        );

        // Set the text of the title shape
        titleShape.TextFrame.Text = "Presentation Overview";

        // Save the presentation to a PPTX file
        presentation.Save("Overview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}