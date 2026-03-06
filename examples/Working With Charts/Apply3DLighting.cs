using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 200, 150, 200, 200);

        // Set the shape's text
        shape.TextFrame.Text = "3D Lighting";

        // Apply 3D lighting settings
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.TopRight;

        // Optional: set material and extrusion height
        shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;
        shape.ThreeDFormat.ExtrusionHeight = 100;

        // Save the presentation
        presentation.Save("3DLighting.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}