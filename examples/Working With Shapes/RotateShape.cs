using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Rotate the shape by 45 degrees clockwise
        shape.Rotation = 45f;

        // Save the presentation to a file
        presentation.Save("RotatedShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}