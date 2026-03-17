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
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a rectangle shape with text
            IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
            shape.TextFrame.Text = "3D";
            shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

            // Apply comprehensive 3D effects
            shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
            shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
            shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
            shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
            shape.ThreeDFormat.Material = MaterialPresetType.Flat;
            shape.ThreeDFormat.ExtrusionHeight = 100;
            shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

            // Export the slide as a JPEG image
            IImage image = pres.Slides[0].GetImage(2f, 2f);
            image.Save("slide_3d.jpg", Aspose.Slides.ImageFormat.Jpeg);

            // Save the presentation file
            pres.Save("output_3d.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}