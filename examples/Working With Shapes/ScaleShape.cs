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

        // Add a rectangle shape to the slide (x=100, y=100, width=200, height=100)
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100f, 100f, 200f, 100f);

        // Store original dimensions
        float originalWidth = shape.Width;
        float originalHeight = shape.Height;

        // Scale the shape: increase width by 50% and height by 75%
        shape.Width = originalWidth * 1.5f;
        shape.Height = originalHeight * 1.75f;

        // Save the presentation
        presentation.Save("ScaledShape.pptx", SaveFormat.Pptx);
    }
}