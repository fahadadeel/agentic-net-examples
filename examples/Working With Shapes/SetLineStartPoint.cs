using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape (auto shape) to the slide
        Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Line, 0, 0, 100, 0);

        // Create a geometry path to define the line's start and end points
        Aspose.Slides.GeometryPath geometryPath = new Aspose.Slides.GeometryPath();

        // Set the start point of the line at (50, 50)
        geometryPath.MoveTo(50f, 50f);

        // Set the end point of the line at (150, 50)
        geometryPath.LineTo(150f, 50f);

        // Apply the custom geometry path to the line shape
        Aspose.Slides.GeometryShape geometryShape = lineShape as Aspose.Slides.GeometryShape;
        if (geometryShape != null)
        {
            geometryShape.SetGeometryPath(geometryPath);
        }

        // Save the presentation
        presentation.Save("LineStartPoint.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}