using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a rectangle shape
            Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 200, 150, 250, 250);

            // Set shape text
            shape.TextFrame.Text = "3D Gradient";
            shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

            // Apply gradient fill
            shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientStops.Add(0, System.Drawing.Color.Blue);
            shape.FillFormat.GradientFormat.GradientStops.Add(100, System.Drawing.Color.Orange);

            // Configure 3‑D properties
            shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
            shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
            shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
            shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
            shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Flat;
            shape.ThreeDFormat.ExtrusionHeight = 100;
            shape.ThreeDFormat.ExtrusionColor.Color = System.Drawing.Color.Blue;

            // Save the presentation
            pres.Save("3d_gradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}