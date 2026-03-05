using System;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 150, 200, 200);

        // Set shape text and font size
        shape.TextFrame.Text = "3D";
        shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

        // Configure 3D format properties
        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
        shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Flat;
        shape.ThreeDFormat.ExtrusionHeight = 100;
        shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

        // Save the presentation in PPTX format
        pres.Save("3DPresentation.pptx", SaveFormat.Pptx);
    }
}