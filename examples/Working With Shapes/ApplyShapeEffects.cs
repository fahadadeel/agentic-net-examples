using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IShape rectShape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            100,   // X position
            100,   // Y position
            200,   // Width
            100);  // Height

        // Apply 3D rotation settings
        rectShape.ThreeDFormat.Depth = 5;
        rectShape.ThreeDFormat.Camera.SetRotation(30, 20, 10);
        rectShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        rectShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;

        // Enable and configure reflection effect
        rectShape.EffectFormat.EnableReflectionEffect();
        rectShape.EffectFormat.ReflectionEffect.Distance = 5.0;

        // Enable and configure soft edge effect
        rectShape.EffectFormat.EnableSoftEdgeEffect();
        rectShape.EffectFormat.SoftEdgeEffect.Radius = 5.0;

        // Save the presentation to a PPTX file
        presentation.Save("ShapeEffects.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}