using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 3"));

        // Add first series and its data points
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 0, 1, 10));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 30));

        // Add second series and its data points
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 0, 2, 15));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 25));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 35));

        // Iterate over series and data points to display an overview
        foreach (Aspose.Slides.Charts.IChartSeries series in chart.ChartData.Series)
        {
            Console.WriteLine("Series Name: " + series.Name);
            int pointIndex = 0;
            foreach (Aspose.Slides.Charts.IChartDataPoint point in series.DataPoints)
            {
                Console.WriteLine("  Point " + pointIndex + ": Value = " + point.Value);
                pointIndex++;
            }
        }

        // Save the presentation
        presentation.Save("ChartSeriesOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}