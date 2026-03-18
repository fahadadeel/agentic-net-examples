using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a thin rectangle that will be transformed into a custom line shape
            IAutoShape baseShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 2) as IAutoShape;

            // Cast to GeometryShape to modify its geometry
            GeometryShape customLine = baseShape as GeometryShape;

            // Define a simple rectangular geometry (acts as a line)
            IGeometryPath geometryPath = new GeometryPath();
            geometryPath.MoveTo(0, 0);
            geometryPath.LineTo(customLine.Width, 0);
            geometryPath.LineTo(customLine.Width, customLine.Height);
            geometryPath.LineTo(0, customLine.Height);
            geometryPath.CloseFigure();

            // Apply the custom geometry (shape type becomes Custom)
            customLine.SetGeometryPath(geometryPath);

            // Configure line formatting
            customLine.LineFormat.Width = 5;
            customLine.LineFormat.FillFormat.FillType = FillType.Solid;
            customLine.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;

            // Save the presentation
            presentation.Save("CustomLine.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}