using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0, 0, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            workbook.Clear(0);
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"),
                chart.Type);

            // Add data points to the series
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 10));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

            // Collect data points from the series
            Aspose.Slides.Charts.IChartDataPointCollection dataPoints = series.DataPoints;
            for (int i = 0; i < dataPoints.Count; i++)
            {
                Aspose.Slides.Charts.IChartDataPoint point = dataPoints[i];
                // Example: output the index of each data point
                Console.WriteLine("Data point index: " + i);
            }

            // Save the presentation
            presentation.Save("DataPointsCollection_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}