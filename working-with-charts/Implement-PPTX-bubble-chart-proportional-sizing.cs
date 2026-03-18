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
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 500, 400);
            var chartData = chart.ChartData;

            // Set bubble size scale (e.g., 150%)
            chartData.Series[0].ParentSeriesGroup.BubbleSizeScale = 150;

            // Use literal double values for bubble sizes
            chartData.Series[0].DataPoints.DataSourceTypeForBubbleSizes = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

            // Add categories (X axis labels)
            var categories = chartData.Categories;
            categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A1", "Category 1"));
            categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2", "Category 2"));
            categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3", "Category 3"));

            // Reference the first series
            var series = chartData.Series[0];

            // Add bubble data points (X, Y, Size)
            series.DataPoints.AddDataPointForBubbleSeries(1.0, 2.0, 30.0);
            series.DataPoints.AddDataPointForBubbleSeries(2.0, 3.0, 50.0);
            series.DataPoints.AddDataPointForBubbleSeries(3.0, 1.5, 20.0);

            // Save the presentation
            presentation.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}