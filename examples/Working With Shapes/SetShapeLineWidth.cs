using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Set the line width (in points)
        lineShape.LineFormat.Width = 5.0;

        // Save the presentation to a file
        presentation.Save("LineWidthPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}