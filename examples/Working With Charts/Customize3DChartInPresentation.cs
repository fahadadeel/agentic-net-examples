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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a 3D clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn3D, 50f, 50f, 600f, 400f);

        // Customize 3D rotation and perspective
        chart.Rotation3D.DepthPercents = 200;      // Depth as a percentage of chart width
        chart.Rotation3D.HeightPercents = 150;     // Height as a percentage of chart width
        chart.Rotation3D.RotationX = -30;          // Rotate around X-axis
        chart.Rotation3D.RotationY = 40;           // Rotate around Y-axis
        chart.Rotation3D.RightAngleAxes = false;   // Enable perspective view

        // Save the presentation
        presentation.Save("Customized3DChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}