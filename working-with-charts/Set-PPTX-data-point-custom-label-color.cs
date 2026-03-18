using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataPointExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Add data points to the series
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                // Choose the first data point
                IChartDataPoint dataPoint = series.DataPoints[0];

                // Set a custom label text
                dataPoint.Label.AddTextFrameForOverriding("Custom Label");

                // Set the fill color of the data point
                dataPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                dataPoint.Format.Fill.SolidFillColor.Color = Color.Blue;

                // Save the presentation
                pres.Save("CustomLabelAndColor.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}