using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart on the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f);

        // Set bubble size scaling (e.g., 150%)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Set bubble size representation to Width
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Populate data for the chart
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default categories and add new ones
        chart.ChartData.Categories.Clear();
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Clear default series and add a new series
        chart.ChartData.Series.Clear();
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points with X, Y, and bubble size values
        series.DataPoints.AddDataPointForBubbleSeries(10.0, 20.0, workbook.GetCell(0, 1, 1, 30.0));
        series.DataPoints.AddDataPointForBubbleSeries(15.0, 25.0, workbook.GetCell(0, 2, 1, 45.0));
        series.DataPoints.AddDataPointForBubbleSeries(20.0, 30.0, workbook.GetCell(0, 3, 1, 60.0));

        // Save the presentation
        presentation.Save("BubbleChartSizes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}