using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];

            // Add a 3D clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 50, 50, 500, 400);

            // Enable and set the chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("3D Chart Example");

            // Customize 3D rotation
            IRotation3D rotation = chart.Rotation3D;
            rotation.RotationX = 20;          // X-axis rotation
            rotation.RotationY = 30;          // Y-axis rotation
            rotation.DepthPercents = 200;    // Depth as percentage of width

            // Format the back wall
            IChartWall backWall = chart.BackWall;
            backWall.Format.Fill.FillType = FillType.Solid;
            backWall.Format.Fill.SolidFillColor.Color = Color.LightGray;

            // Format the floor
            IChartWall floor = chart.Floor;
            floor.Format.Fill.FillType = FillType.Solid;
            floor.Format.Fill.SolidFillColor.Color = Color.White;

            // Format the side wall
            IChartWall sideWall = chart.SideWall;
            sideWall.Format.Fill.FillType = FillType.Solid;
            sideWall.Format.Fill.SolidFillColor.Color = Color.LightBlue;

            // Save the presentation
            pres.Save("3DChartFormatted.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}