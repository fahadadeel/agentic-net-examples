using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first (empty) slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to serve as the title placeholder
        Aspose.Slides.IAutoShape titleShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);

        // Set the text of the shape to "Overview"
        titleShape.TextFrame.Text = "Overview";

        // Save the presentation to a file
        presentation.Save("OverviewPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}