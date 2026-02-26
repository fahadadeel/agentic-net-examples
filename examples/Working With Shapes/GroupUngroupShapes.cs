using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Access the shape collection of the slide
        IShapeCollection shapes = slide.Shapes;

        // Add individual shapes to the slide
        IShape rect1 = shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IShape rect2 = shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);
        IShape rect3 = shapes.AddAutoShape(ShapeType.Triangle, 350, 50, 100, 100);

        // Create a group shape and add clones of the individual shapes
        IGroupShape group = shapes.AddGroupShape();
        group.Shapes.AddClone(rect1);
        group.Shapes.AddClone(rect2);
        group.Shapes.AddClone(rect3);

        // Remove the original shapes from the slide (they are now inside the group)
        shapes.Remove(rect1);
        shapes.Remove(rect2);
        shapes.Remove(rect3);

        // Ungroup: clone each shape from the group back to the slide
        IShapeCollection groupShapes = group.Shapes;
        for (int i = 0; i < groupShapes.Count; i++)
        {
            IShape innerShape = groupShapes[i];
            shapes.AddClone(innerShape);
        }

        // Remove the now empty group shape
        shapes.Remove(group);

        // Save the presentation
        presentation.Save("GroupUngroupDemo.pptx", SaveFormat.Pptx);
    }
}