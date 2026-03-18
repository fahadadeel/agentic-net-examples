using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a 3D clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn3D, 50, 50, 500, 400);

                // Enable and set the chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("3D Column Chart");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                // Configure 3D rotation and perspective
                chart.Rotation3D.DepthPercents = 150;
                chart.Rotation3D.HeightPercents = 100;
                chart.Rotation3D.Perspective = 30;
                chart.Rotation3D.RotationX = 20;
                chart.Rotation3D.RotationY = 30;
                chart.Rotation3D.RightAngleAxes = false;

                // Hide both axes using the correct property
                chart.Axes.VerticalAxis.IsVisible = false;
                chart.Axes.HorizontalAxis.IsVisible = false;

                // Apply a predefined chart style
                chart.Style = Aspose.Slides.Charts.StyleType.Style3;

                // Save the presentation
                pres.Save("Custom3DChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}