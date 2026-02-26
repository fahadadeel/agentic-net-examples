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

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Set the line dash style of the shape
        lineShape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;

        // Save the presentation
        presentation.Save("ShapeLineDashStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}