using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50, 50, 500, 400);

        // Access the 3D rotation object (read‑only property) and set its values
        Aspose.Slides.Charts.IRotation3D rotation = chart.Rotation3D;
        rotation.RotationX = 30;          // sbyte: rotation around X‑axis
        rotation.RotationY = 40;          // ushort: rotation around Y‑axis
        rotation.RightAngleAxes = false; // use perspective
        rotation.Perspective = 30;        // byte: perspective angle

        // Save the presentation to a file
        presentation.Save("3DChartRotation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}