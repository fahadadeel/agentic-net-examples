using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Set the line width (in points)
        lineShape.LineFormat.Width = 5.0;

        // Save the presentation to a file
        presentation.Save("LineWidth_out.pptx", SaveFormat.Pptx);
    }
}