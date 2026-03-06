using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a 3D clustered column chart
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn3D, 50, 50, 400, 300);

        // Set 3D rotation properties
        chart.Rotation3D.RotationX = (sbyte)30;      // X-axis rotation
        chart.Rotation3D.RotationY = (ushort)45;    // Y-axis rotation
        chart.Rotation3D.DepthPercents = (ushort)200; // Depth percentage

        // Save the presentation
        presentation.Save("3DChartRotation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}