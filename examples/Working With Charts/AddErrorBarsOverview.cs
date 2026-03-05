using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace ErrorBarsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            var slide = presentation.Slides[0];

            // Add a clustered column chart
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get reference to the default worksheet
            var defaultWorksheetIndex = 0;
            var chartDataWorkbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add first series and populate data points
            var series1 = chart.ChartData.Series.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            series1.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Add second series and populate data points
            var series2 = chart.ChartData.Series.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);
            series2.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

            // Configure error bars for the first series (Y direction)
            var errorBars = series1.ErrorBarsYFormat;
            errorBars.IsVisible = true;                                 // Show error bars
            errorBars.Type = Aspose.Slides.Charts.ErrorBarType.Both;    // Both positive and negative
            errorBars.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage; // Use percentage
            errorBars.Value = 10f;                                      // 10% of the data point value

            // Save the presentation
            presentation.Save("ErrorBarsOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}