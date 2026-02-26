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

        // Add a rectangle shape to display a number
        Aspose.Slides.IAutoShape numberShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, // shape type
            50,   // X position
            50,   // Y position
            100,  // width
            50    // height
        );

        // Insert the number text into the shape
        numberShape.AddTextFrame("1");

        // Save the updated presentation as PPTX
        presentation.Save("NumbersPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}