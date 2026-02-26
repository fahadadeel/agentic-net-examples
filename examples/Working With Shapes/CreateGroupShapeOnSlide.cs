using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Access the shape collection of the slide
        Aspose.Slides.IShapeCollection shapeCollection = slide.Shapes;

        // Add an empty group shape to the slide
        Aspose.Slides.IGroupShape groupShape = shapeCollection.AddGroupShape();

        // Add some rectangle shapes inside the group
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 100, 100, 100);
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 500, 100, 100, 100);
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 300, 100, 100);
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 500, 300, 100, 100);

        // Save the presentation
        pres.Save("GroupShapeExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}