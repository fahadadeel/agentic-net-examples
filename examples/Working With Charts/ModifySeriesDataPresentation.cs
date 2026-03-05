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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Access the chart's data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories to the chart
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 3"));

        // Add a new series to the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"),
            chart.Type);

        // Populate the series with initial data points
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 10));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 20));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

        // Modify the second data point: remove it and add a new value
        Aspose.Slides.Charts.IChartDataPoint pointToRemove = series.DataPoints[1];
        pointToRemove.Remove(); // Remove the existing point

        // Add a new data point at the end (could be re‑ordered if needed)
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));

        // Save the modified presentation
        presentation.Save("ModifiedSeriesData.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}