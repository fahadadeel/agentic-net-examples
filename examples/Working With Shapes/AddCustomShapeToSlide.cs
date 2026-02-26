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

        // Add a rectangle auto shape and cast it to GeometryShape
        Aspose.Slides.GeometryShape geometryShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 200f, 100f) as Aspose.Slides.GeometryShape;

        // Create a custom geometry path
        Aspose.Slides.GeometryPath geometryPath = new Aspose.Slides.GeometryPath();
        geometryPath.MoveTo(0f, 0f);
        geometryPath.LineTo(geometryShape.Width, 0f);
        geometryPath.LineTo(geometryShape.Width, geometryShape.Height / 2f);
        geometryPath.LineTo(0f, geometryShape.Height / 2f);
        geometryPath.CloseFigure();

        // Apply the custom geometry to the shape
        geometryShape.SetGeometryPath(geometryPath);

        // Save the presentation
        presentation.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}