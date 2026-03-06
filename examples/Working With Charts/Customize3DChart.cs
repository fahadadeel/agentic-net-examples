using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
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
                50f, 50f, 500f, 400f);

            // Customize the 3D rotation of the chart
            Aspose.Slides.Charts.IRotation3D rotation = chart.Rotation3D;
            rotation.DepthPercents = 200;      // Depth as a percentage of chart width
            rotation.HeightPercents = 150;     // Height as a percentage of chart width
            rotation.RotationX = -30;          // Rotate around X axis
            rotation.RotationY = 40;           // Rotate around Y axis
            rotation.RightAngleAxes = false;   // Enable perspective view

            // Set the back wall fill color
            Aspose.Slides.Charts.IChartWall backWall = chart.BackWall;
            backWall.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            backWall.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightGray;

            // Set the floor fill color
            Aspose.Slides.Charts.IChartWall floor = chart.Floor;
            floor.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            floor.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightGray;

            // Save the presentation to a PPTX file
            presentation.Save("Customize3DChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}