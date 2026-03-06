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

        // Set bubble size scaling (e.g., 150% of default size)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Access the chart's data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add a new series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 0, "Series 1"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add data points (X value, Y value, Bubble size)
        Aspose.Slides.Charts.IChartDataPointCollection points = series.DataPoints;
        points.AddDataPointForBubbleSeries(1.0, 4.0, 10.0);
        points.AddDataPointForBubbleSeries(2.0, 5.0, 20.0);
        points.AddDataPointForBubbleSeries(3.0, 6.0, 30.0);

        // Save the presentation
        presentation.Save("BubbleChartScaling.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}