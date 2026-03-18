using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50, 50, 500, 400, true);

            // Access chart data
            Aspose.Slides.Charts.IChartData chartData = chart.ChartData;
            chartData.Series.Clear();
            chartData.Categories.Clear();

            // Add categories
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A1", "Category 1"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2", "Category 2"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3", "Category 3"));

            // Add a series with sample values
            Aspose.Slides.Charts.IChartSeries series = chartData.Series.Add(
                chartData.ChartDataWorkbook.GetCell(0, "B1", "Series 1"),
                chart.Type);
            series.DataPoints.AddDataPointForBarSeries(chartData.ChartDataWorkbook.GetCell(0, "B2", 0.2));
            series.DataPoints.AddDataPointForBarSeries(chartData.ChartDataWorkbook.GetCell(0, "B3", 0.5));
            series.DataPoints.AddDataPointForBarSeries(chartData.ChartDataWorkbook.GetCell(0, "B4", 0.8));

            // Configure data labels to show values with a percentage sign
            series.Labels.DefaultDataLabelFormat.ShowValue = true;
            series.Labels.DefaultDataLabelFormat.ShowPercentage = true;
            series.Labels.DefaultDataLabelFormat.NumberFormat = "0%";

            // Save the presentation
            presentation.Save("ChartDataLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}