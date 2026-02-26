using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomizeBubbleChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a bubble chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f, 50f, 600f, 400f);

            // Set bubble size representation to Width (uses rule: support-of-bubble-size-representation)
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

            // Set bubble size scale (uses rule: support-for-bubble-chart-scaling)
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // 150% of default size

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Define default worksheet index
            int defaultWorksheetIndex = 0;

            // Add a new series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);

            // Add categories (required for X axis labels)
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate the series with bubble data points (X, Y, BubbleSize)
            series.DataPoints.AddDataPointForBubbleSeries(1.0, 2.0, 30.0);
            series.DataPoints.AddDataPointForBubbleSeries(2.0, 4.0, 50.0);
            series.DataPoints.AddDataPointForBubbleSeries(3.0, 1.5, 20.0);

            // Save the presentation
            presentation.Save("CustomizeBubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}