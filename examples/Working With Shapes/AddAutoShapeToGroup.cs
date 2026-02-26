using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define output folder and file
        string outputFolder = "Output" + Path.DirectorySeparatorChar;
        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);
        string outputFile = outputFolder + "GroupShape_out.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Access the shape collection of the slide
        IShapeCollection slideShapes = slide.Shapes;

        // Add an empty group shape to the slide
        IGroupShape groupShape = slideShapes.AddGroupShape();

        // Add auto shapes inside the group shape
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

        // Set the frame for the group shape
        groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

        // Save the presentation
        pres.Save(outputFile, SaveFormat.Pptx);
    }
}