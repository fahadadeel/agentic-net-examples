using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            var pres = new Aspose.Slides.Presentation();
            var slide = pres.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 150, 200, 200);
            shape.TextFrame.Text = "3D Shape";
            shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

            // Apply 3D formatting
            shape.ThreeDFormat.Depth = 50;
            shape.ThreeDFormat.ExtrusionHeight = 100;
            shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;
            shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
            shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
            shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
            shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
            shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

            // Save the presentation
            pres.Save("ThreeDShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}