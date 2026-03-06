using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        Aspose.Slides.Charts.IChartCategory category1 = chart.ChartData.Categories.Add(
            workbook.GetCell(0, 0, 0, "Category 1"));
        Aspose.Slides.Charts.IChartCategory category2 = chart.ChartData.Categories.Add(
            workbook.GetCell(0, 1, 0, "Category 2"));

        // Add series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

        // Populate data points for series 1
        series1.DataPoints.AddDataPointForBarSeries(
            workbook.GetCell(0, 1, 1, 10));
        series1.DataPoints.AddDataPointForBarSeries(
            workbook.GetCell(0, 2, 1, 20));

        // Populate data points for series 2
        series2.DataPoints.AddDataPointForBarSeries(
            workbook.GetCell(0, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(
            workbook.GetCell(0, 2, 2, 40));

        // Save the presentation
        presentation.Save("ClusteredColumnChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}