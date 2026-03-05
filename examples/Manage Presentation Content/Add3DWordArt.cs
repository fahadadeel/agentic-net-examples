using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 150, 250, 250);

        // Set the text
        shape.TextFrame.Text = "3D Text";

        // No fill for shape
        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

        // Configure portion formatting
        Aspose.Slides.Portion portion = (Aspose.Slides.Portion)shape.TextFrame.Paragraphs[0].Portions[0];
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
        portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
        portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
        portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.LargeGrid;

        // Set font height
        shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

        // Apply WordArt transform effect
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
        textFrame.TextFrameFormat.Transform = Aspose.Slides.TextShapeType.ArchUp;

        // Set 3D format for text
        textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5;
        textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;
        textFrame.TextFrameFormat.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;
        textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
        textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
        textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
        textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.PerspectiveContrastingRightFacing;

        // Save the presentation
        pres.Save("text3d.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose presentation
        pres.Dispose();
    }
}