using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Enable and set the chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("3D Chart Example");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

        // Configure 3D rotation of the chart
        chart.Rotation3D.RotationX = 20;          // Rotation around X‑axis
        chart.Rotation3D.RotationY = 30;          // Rotation around Y‑axis
        chart.Rotation3D.DepthPercents = 150;    // Depth as percentage of width
        chart.Rotation3D.HeightPercents = 100;   // Height as percentage of width
        chart.Rotation3D.Perspective = 30;       // Perspective angle
        chart.Rotation3D.RightAngleAxes = false; // Use perspective axes

        // Apply additional 3D formatting
        chart.ThreeDFormat.Depth = 30;                                 // Depth of the 3D shape
        chart.ThreeDFormat.ExtrusionHeight = 20;                       // Extrusion height
        chart.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;
        chart.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
        chart.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
        chart.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.PerspectiveContrastingRightFacing;
        chart.ThreeDFormat.Camera.SetRotation(0, 0, 40);               // Camera rotation

        // Save the presentation to a PPTX file
        pres.Save("Custom3DChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}