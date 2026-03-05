using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Add a rectangle auto shape to the first slide
                IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

                // Cast the auto shape to GeometryShape to allow custom geometry
                GeometryShape geometryShape = autoShape as GeometryShape;

                // Define a custom triangular geometry path
                GeometryPath geometryPath = new GeometryPath();
                geometryPath.MoveTo(0, 0);
                geometryPath.LineTo(geometryShape.Width, 0);
                geometryPath.LineTo(geometryShape.Width / 2, geometryShape.Height);
                geometryPath.CloseFigure();

                // Apply the custom geometry to the shape
                geometryShape.SetGeometryPath(geometryPath);

                // Set solid fill color
                geometryShape.FillFormat.FillType = FillType.Solid;
                geometryShape.FillFormat.SolidFillColor.Color = Color.Yellow;

                // Set line (stroke) formatting
                geometryShape.LineFormat.Width = 3;
                geometryShape.LineFormat.FillFormat.FillType = FillType.Solid;
                geometryShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;

                // Save the presentation
                pres.Save("CustomShape.pptx", SaveFormat.Pptx);
            }
        }
    }
}