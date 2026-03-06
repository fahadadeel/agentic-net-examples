using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line, 0f, 0f, 500f, 400f);

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add series
        chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(
            workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(
            workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(
            workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Populate data points for the first series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
        series1.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
        series1.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
        series1.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

        // Populate data points for the second series
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
        series2.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
        series2.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
        series2.DataPoints.AddDataPointForLineSeries(
            workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));

        // Save the presentation
        presentation.Save("LineChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}