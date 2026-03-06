using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a Treemap chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 50, 50, 500, 400);

        // Get the first series of the chart
        IChartSeries series = chart.ChartData.Series[0];

        // Ensure the series has at least one data point
        if (series.DataPoints.Count == 0)
        {
            // Add a sample data point with a value of 10
            series.DataPoints.AddDataPointForTreemapSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", 10));
        }

        // Get the first data point
        IChartDataPoint dataPoint = series.DataPoints[0];

        // Access a specific branch level (e.g., level 0)
        IChartDataPointLevel branchLevel = dataPoint.DataPointLevels[0];

        // Set the fill type to solid and assign a color
        branchLevel.Format.Fill.FillType = FillType.Solid;
        branchLevel.Format.Fill.SolidFillColor.Color = Color.Green;

        // Save the presentation
        presentation.Save("SetBranchColor_out.pptx", SaveFormat.Pptx);
    }
}