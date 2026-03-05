using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UngroupShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "UngroupShape_out.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Get the shape collection of the slide
            Aspose.Slides.IShapeCollection slideShapes = slide.Shapes;

            // Add a group shape to the slide
            Aspose.Slides.IGroupShape groupShape = slideShapes.AddGroupShape();

            // Add some shapes inside the group
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 150, 80);
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300, 120, 100, 100);
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 250, 120, 60);

            // Ungroup: clone each inner shape to the slide and then remove the group
            for (int i = 0; i < groupShape.Shapes.Count; i++)
            {
                Aspose.Slides.IShape innerShape = groupShape.Shapes[i];
                // Clone the shape onto the slide (preserves position and size)
                slideShapes.AddClone(innerShape);
            }

            // Remove the original group shape
            slideShapes.Remove(groupShape);

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}