using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
            shape.TextFrame.Text = "3D Lighting";

            // Apply 3D lighting effects
            shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
            shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
            shape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

            // Save the presentation
            presentation.Save("3DLighting.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}