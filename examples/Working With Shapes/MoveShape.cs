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

        // Add a rectangle shape at initial position (50,50) with size 100x50
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50f, 50f, 100f, 50f);

        // Define new X and Y coordinates
        float newX = 200f;
        float newY = 150f;

        // Move the shape to the new coordinates
        shape.X = newX;
        shape.Y = newY;

        // Save the presentation before exiting
        presentation.Save("MovedShape.pptx", SaveFormat.Pptx);
    }
}