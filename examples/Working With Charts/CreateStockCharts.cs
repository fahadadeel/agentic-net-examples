using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a High-Low-Close stock chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.HighLowClose, 50f, 50f, 500f, 400f);

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories (e.g., months)
        chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 0, "Jan"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Feb"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Mar"));

        // Add a series
        chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Get the created series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Add stock data points (close values for simplicity)
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 0, 1, 120.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 130.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 125.0));

        // Save the presentation
        presentation.Save("StockChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}