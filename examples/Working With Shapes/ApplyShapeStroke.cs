using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle autoshape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Cast to GeometryShape to modify geometry
        Aspose.Slides.GeometryShape geometryShape = autoShape as Aspose.Slides.GeometryShape;

        // Create a custom geometry path (triangle)
        Aspose.Slides.GeometryPath geometryPath = new Aspose.Slides.GeometryPath();
        geometryPath.MoveTo(0, 0);
        geometryPath.LineTo(geometryShape.Width, 0);
        geometryPath.LineTo(geometryShape.Width / 2, geometryShape.Height);
        geometryPath.CloseFigure();

        // Apply custom geometry to the shape
        geometryShape.SetGeometryPath(geometryPath);

        // Apply stroke (line) formatting
        Aspose.Slides.ILineFormat lineFormat = geometryShape.LineFormat;
        lineFormat.Width = 5; // line width in points
        lineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        lineFormat.FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation
        presentation.Save("CustomShapeWithStroke.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}