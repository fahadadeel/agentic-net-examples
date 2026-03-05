using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Set line style of the rectangle
        rectangle.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;
        rectangle.LineFormat.Width = 5.0;

        // Save the presentation
        presentation.Save("RectangleLineStyle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}