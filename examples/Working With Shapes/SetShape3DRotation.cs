using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

        // Set rotation around the Z-axis (shape rotation)
        shape.Rotation = 45f; // 45 degrees clockwise

        // Set rotation around the X and Y axes using the shape's 3D camera
        shape.ThreeDFormat.Camera.SetRotation(30, 20, 0); // X=30°, Y=20°, Z=0°

        // Save the presentation
        pres.Save("Shape3DRotation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}