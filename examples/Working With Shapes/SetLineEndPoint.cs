using System;
using Aspose.Slides;

namespace SetLineEndPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "SetLineEndPoint.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a line shape to the slide
            Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

            // Get the geometry interface of the line
            Aspose.Slides.IGeometryShape geometryShape = line.AsIGeometryShape;

            // Retrieve the existing geometry path
            Aspose.Slides.IGeometryPath geometryPath = geometryShape.GetGeometryPaths()[0];

            // Set a new end point for the line (index 1 corresponds to the line segment)
            geometryPath.LineTo(400f, 150f, 1);

            // Apply the modified geometry back to the shape
            geometryShape.SetGeometryPath(geometryPath);

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}