using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GroupAndUngroupShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an empty group shape to the slide
            Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Add multiple shapes inside the group
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 150, 100);
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300, 100, 150, 100);
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 250, 150, 100);
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300, 250, 150, 100);

            // Ungroup: clone each inner shape back to the slide and remove the group
            for (int i = 0; i < groupShape.Shapes.Count; i++)
            {
                Aspose.Slides.IShape innerShape = groupShape.Shapes[i];
                // Clone the shape onto the slide (preserves position and size)
                slide.Shapes.AddClone(innerShape);
            }

            // Remove the original group shape
            slide.Shapes.Remove(groupShape);

            // Save the presentation
            presentation.Save("GroupAndUngroup_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}