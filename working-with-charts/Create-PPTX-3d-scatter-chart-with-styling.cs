using System;
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
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a scatter chart (ScatterWithMarkers) – it can be displayed in 3D using rotation settings
                IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 50, 50, 500, 400);

                // Enable and set the chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("3D Scatter Chart");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

                // Configure 3D rotation for the chart
                IRotation3D rotation = chart.Rotation3D;
                rotation.RotationX = 20;          // Tilt around X‑axis
                rotation.RotationY = 30;          // Tilt around Y‑axis
                rotation.DepthPercents = 200;    // Depth of the 3D chart
                rotation.HeightPercents = 150;   // Height percentage
                rotation.Perspective = 30;       // Perspective angle

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.ScatterWithMarkers);
                // Enable varied colors for each data point
                series.ParentSeriesGroup.IsColorVaried = true;

                // Populate the series with data points (X, Y)
                series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(0, 1, 1, 10), workbook.GetCell(0, 1, 2, 20));
                series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(0, 2, 1, 30), workbook.GetCell(0, 2, 2, 25));
                series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(0, 3, 1, 50), workbook.GetCell(0, 3, 2, 40));

                // Save the presentation
                pres.Save("3DScatterChart.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}