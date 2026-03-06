using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a funnel chart on the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Funnel, 50f, 50f, 500f, 400f);

        // Clear default categories and series
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear the workbook (optional)
        workbook.Clear(0);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Stage 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Stage 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Stage 3"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Stage 4"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Stage 5"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Stage 6"));

        // Add a series for the funnel chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Funnel);

        // Add data points for each category
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 100));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 80));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 60));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 40));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 20));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 10));

        // Save the presentation
        presentation.Save("FunnelChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}