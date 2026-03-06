using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 40));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

        // Configure error bars for Y direction
        Aspose.Slides.Charts.IErrorBarsFormat errorBars = series.ErrorBarsYFormat;
        errorBars.IsVisible = true;
        errorBars.Type = Aspose.Slides.Charts.ErrorBarType.Both;
        errorBars.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
        errorBars.Value = 5f;

        // Save the presentation
        pres.Save("ErrorBarsChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}