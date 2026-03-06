using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a 3D clustered column chart to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn3D, 50, 50, 500, 400);

            // Set 3D rotation properties
            chart.Rotation3D.RotationX = 30;          // Rotate around X-axis
            chart.Rotation3D.RotationY = 40;          // Rotate around Y-axis
            chart.Rotation3D.DepthPercents = 150;    // Set depth as percentage of chart width

            // Save the presentation
            pres.Save("3DChartRotation.pptx", SaveFormat.Pptx);
        }
    }
}