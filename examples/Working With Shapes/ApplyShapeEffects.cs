using System;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

        // Set some text for the shape
        shape.TextFrame.Text = "3D with Effects";

        // Apply 3D rotation and material
        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        shape.ThreeDFormat.Camera.SetRotation(30, 20, 10);
        shape.ThreeDFormat.Depth = 5;
        shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;

        // Enable and configure reflection effect
        shape.EffectFormat.EnableReflectionEffect();
        shape.EffectFormat.ReflectionEffect.BlurRadius = 2.0;
        shape.EffectFormat.ReflectionEffect.Distance = 5.0;
        shape.EffectFormat.ReflectionEffect.RotateShadowWithShape = true;

        // Enable and configure soft edge effect
        shape.EffectFormat.EnableSoftEdgeEffect();
        shape.EffectFormat.SoftEdgeEffect.Radius = 4.0;

        // Save the presentation to a file
        presentation.Save("Shape3DEffects.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}