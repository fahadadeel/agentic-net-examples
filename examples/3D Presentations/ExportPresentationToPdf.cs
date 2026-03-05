using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 200, 150, 200, 200);

        // Set shape text
        shape.TextFrame.Text = "3D";
        shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

        // Configure 3D format
        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
        shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Flat;
        shape.ThreeDFormat.ExtrusionHeight = 100;
        shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

        // Save the presentation (PPTX) before exiting
        presentation.Save("output_3d.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Export the presentation with 3D effects to PDF
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        presentation.Save("output_3d.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
    }
}