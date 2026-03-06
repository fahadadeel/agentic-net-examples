using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Access chart data
        Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

        // Clear default series and categories
        chartData.Series.Clear();
        chartData.Categories.Clear();

        // Add categories
        chartData.Categories.Add("Category 1");
        chartData.Categories.Add("Category 2");
        chartData.Categories.Add("Category 3");

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chartData.Series.Add(
            Aspose.Slides.Charts.ChartType.ClusteredColumn);

        // Add data points to the series
        series.DataPoints.AddDataPointForBarSeries(10);
        series.DataPoints.AddDataPointForBarSeries(20);
        series.DataPoints.AddDataPointForBarSeries(30);

        // Add a linear trendline to the series
        Aspose.Slides.Charts.ITrendline trendline = series.TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear);
        trendline.DisplayEquation = true;
        trendline.DisplayRSquaredValue = true;

        // Save the presentation
        presentation.Save("AddTrendLine_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}