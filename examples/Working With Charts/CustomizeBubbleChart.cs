using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

        // Set bubble size representation to Width
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Set bubble size scale (e.g., 150%)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        int defaultWorksheetIndex = 0;
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

        // Add bubble data points (X value, Y value, Bubble size)
        series.DataPoints.AddDataPointForBubbleSeries(1.0, 4.0, 30.0);
        series.DataPoints.AddDataPointForBubbleSeries(2.0, 5.0, 40.0);
        series.DataPoints.AddDataPointForBubbleSeries(3.0, 6.0, 50.0);

        // Show bubble size values in data labels
        series.Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

        // Save the presentation
        presentation.Save("CustomizedBubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}