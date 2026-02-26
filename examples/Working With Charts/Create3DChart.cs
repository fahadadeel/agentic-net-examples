using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Create3DChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a 3D clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn3D,
                50f, 50f, 600f, 400f);

            // Configure 3D rotation properties
            // HeightPercents and DepthPercents define the chart's 3D size
            chart.Rotation3D.HeightPercents = 150; // 150% of chart width
            chart.Rotation3D.DepthPercents = 200;  // 200% of chart width

            // Set rotation angles around X and Y axes
            chart.Rotation3D.RotationX = -30; // tilt upward
            chart.Rotation3D.RotationY = 40;  // rotate to the right

            // Optionally enable right-angle axes for a more orthogonal view
            chart.Rotation3D.RightAngleAxes = true;

            // Save the presentation to a PPTX file
            presentation.Save("3DChartOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}