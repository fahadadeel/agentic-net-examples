using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sample Chart with Error Bars");

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add first series and populate data points
            IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 10));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

            // Configure Y-direction error bars for the first series
            IErrorBarsFormat errBars1 = series1.ErrorBarsYFormat;
            errBars1.IsVisible = true;
            errBars1.Type = ErrorBarType.Both;
            errBars1.ValueType = ErrorBarValueType.Percentage;
            errBars1.Value = 10f; // 10% error bars

            // Add second series and populate data points
            IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 15));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 25));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 35));

            // Save the presentation
            pres.Save("ErrorBarsChart.pptx", SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}