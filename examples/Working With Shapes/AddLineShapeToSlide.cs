using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LineShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line auto shape to the slide
            AutoShape lineShape = (AutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50f, 150f, 300f, 0f);

            // Customize line formatting
            ILineFormat lineFormat = lineShape.LineFormat;
            lineFormat.Width = 5f;
            lineFormat.FillFormat.SolidFillColor.Color = Color.Red;

            // Optionally modify the geometry of the line shape
            GeometryPath geometryPath = new GeometryPath();
            geometryPath.MoveTo(0f, 0f);
            geometryPath.LineTo(lineShape.Width, 0f);
            lineShape.SetGeometryPath(geometryPath);

            // Save the presentation
            presentation.Save("LineShape.pptx", SaveFormat.Pptx);
        }
    }
}