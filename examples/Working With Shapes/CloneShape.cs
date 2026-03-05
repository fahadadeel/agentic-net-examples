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

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape originalShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 200f, 100f);

        // Clone the shape and add it to the slide
        Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(originalShape);

        // Move the cloned shape to a new position
        clonedShape.X = 300f;
        clonedShape.Y = 150f;

        // Save the presentation
        presentation.Save("ClonedShapePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}