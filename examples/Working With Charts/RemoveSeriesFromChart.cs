using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 0, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 3"));

        // Add two series
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Populate data for Series 1
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

        // Populate data for Series 2
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));

        // Remove the second series (index 1)
        chart.ChartData.Series.RemoveAt(1);

        // Save the presentation
        presentation.Save("RemoveSeries_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}