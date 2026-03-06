using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a funnel chart on the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Funnel, 0f, 0f, 500f, 400f);

        // Remove default categories and series
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        // Access the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        workbook.Clear(0);

        // Define categories for the funnel
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Prospects"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Qualified Leads"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Proposals"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Negotiations"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Closed Won"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Closed Lost"));

        // Add a series for the funnel chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Funnel);

        // Populate the series with data points
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 1000));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 800));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 600));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 400));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 200));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 100));

        // Save the presentation
        presentation.Save("FunnelChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}