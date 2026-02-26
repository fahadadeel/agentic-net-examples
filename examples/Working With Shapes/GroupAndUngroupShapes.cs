using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Access the shape collection of the slide
        Aspose.Slides.IShapeCollection slideShapes = slide.Shapes;

        // Add a new empty group shape
        Aspose.Slides.IGroupShape group = slideShapes.AddGroupShape();

        // Add multiple rectangle shapes to the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 100, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 500, 100, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 300, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 500, 300, 100, 100);

        // Optionally set the group shape's frame
        group.Frame = new Aspose.Slides.ShapeFrame(100, 300, 500, 40, Aspose.Slides.NullableBool.False, Aspose.Slides.NullableBool.False, 0);

        // Ungroup: clone each inner shape to the slide and then remove the group shape
        for (int i = 0; i < group.Shapes.Count; i++)
        {
            Aspose.Slides.IShape innerShape = group.Shapes[i];
            slideShapes.AddClone(innerShape);
        }
        slideShapes.Remove(group);

        // Save the presentation
        presentation.Save("GroupAndUngroup_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}