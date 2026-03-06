using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a doughnut chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50, 50, 500, 400);

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add a series
        IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));

        // Add data points for the doughnut series
        series.DataPoints.AddDataPointForDoughnutSeries(30);
        series.DataPoints.AddDataPointForDoughnutSeries(70);

        // Enable callout (leader line) for the first data point
        IDataLabel dataLabel = series.DataPoints[0].Label;
        dataLabel.DataLabelFormat.ShowLeaderLines = true;

        // Save the presentation
        presentation.Save("DoughnutCallout_out.pptx", SaveFormat.Pptx);
    }
}