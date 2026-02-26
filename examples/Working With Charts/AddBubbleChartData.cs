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
        var presentation = new Aspose.Slides.Presentation();
        var slide = presentation.Slides[0];

        // Add a bubble chart
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 500, 400);

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the default worksheet index and workbook
        int defaultWorksheetIndex = 0;
        var chartDataWorkbook = chart.ChartData.ChartDataWorkbook;

        // Add series
        var series1 = chart.ChartData.Series.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        var series2 = chart.ChartData.Series.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add data points for the first series (X, Y, BubbleSize)
        series1.DataPoints.AddDataPointForBubbleSeries(1.0, 4.0, chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 1, 30.0));
        series1.DataPoints.AddDataPointForBubbleSeries(2.0, 5.0, chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 1, 40.0));
        series1.DataPoints.AddDataPointForBubbleSeries(3.0, 6.0, chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 1, 50.0));

        // Add data points for the second series
        series2.DataPoints.AddDataPointForBubbleSeries(1.0, 7.0, chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 2, 20.0));
        series2.DataPoints.AddDataPointForBubbleSeries(2.0, 8.0, chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 2, 30.0));
        series2.DataPoints.AddDataPointForBubbleSeries(3.0, 9.0, chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 2, 40.0));

        // Show bubble size in data labels
        series1.DataPoints[0].Label.DataLabelFormat.ShowBubbleSize = true;
        series2.DataPoints[0].Label.DataLabelFormat.ShowBubbleSize = true;

        // Save the presentation
        presentation.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}