using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BubbleChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var presentation = new Aspose.Slides.Presentation();
                var slide = presentation.Slides[0];

                // Add a bubble chart
                var chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Bubble,
                    50f, 50f, 500f, 400f);

                // Clear default data
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                var defaultWorksheetIndex = 0;
                var chartDataWorkbook = chart.ChartData.ChartDataWorkbook;

                // Add a series
                var series = chart.ChartData.Series.Add(
                    chartDataWorkbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                    chart.Type);

                // Set series fill and enable varied colors
                series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series.Format.Fill.SolidFillColor.Color = Color.Red;
                series.ParentSeriesGroup.IsColorVaried = true;

                // Add categories (X axis labels)
                chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 0, "A"));
                chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 0, "B"));
                chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 0, "C"));

                // Add bubble data points (X, Y, Size)
                var dataPoint = series.DataPoints.AddDataPointForBubbleSeries(1.0, 4.0, 30.0);
                dataPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                dataPoint.Format.Fill.SolidFillColor.Color = Color.Green;

                dataPoint = series.DataPoints.AddDataPointForBubbleSeries(2.0, 2.5, 50.0);
                dataPoint = series.DataPoints.AddDataPointForBubbleSeries(3.0, 5.0, 20.0);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Custom Bubble Chart");

                // Save the presentation
                presentation.Save("CustomBubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}