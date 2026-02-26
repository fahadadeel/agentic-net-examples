using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape originalShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 200f, 100f);

        // Clone the shape and place the clone at a new position
        Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(originalShape, 350f, 100f);

        // Save the presentation
        presentation.Save("ClonedShapePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}