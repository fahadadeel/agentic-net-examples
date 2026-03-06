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
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Get chart data workbook
        Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

        // Clear default series and categories
        chartData.Series.Clear();
        chartData.Categories.Clear();

        // Add categories
        chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A1", "Category 1"));
        chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2", "Category 2"));
        chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3", "Category 3"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chartData.Series.Add(
            Aspose.Slides.Charts.ChartType.ClusteredColumn);

        // Add data points
        series.DataPoints.AddDataPointForBarSeries(chartData.ChartDataWorkbook.GetCell(0, "B1", 20));
        series.DataPoints.AddDataPointForBarSeries(chartData.ChartDataWorkbook.GetCell(0, "B2", 50));
        series.DataPoints.AddDataPointForBarSeries(chartData.ChartDataWorkbook.GetCell(0, "B3", 30));

        // Enable data labels and set precision
        series.Labels.DefaultDataLabelFormat.ShowValue = true;
        series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
        series.Labels.DefaultDataLabelFormat.NumberFormat = "0.00";

        // Save the presentation
        presentation.Save("SetDataPrecision_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}