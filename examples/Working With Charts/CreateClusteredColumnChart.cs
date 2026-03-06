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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add a category
        chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 0, "Category 1"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points to the series
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 10));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 20));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

        // Save the presentation
        presentation.Save("ClusteredColumnChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}