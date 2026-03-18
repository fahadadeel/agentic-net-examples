using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a bubble chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 500, 400, true);

            // Access chart data
            IChartData chartData = chart.ChartData;

            // Clear default series and categories
            chartData.Series.Clear();
            chartData.Categories.Clear();

            // Add categories (X axis labels)
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A1", "Category 1"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2", "Category 2"));
            chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3", "Category 3"));

            // Add a bubble series
            IChartSeries series = chartData.Series.Add(ChartType.Bubble);

            // Set bubble size representation (area proportional)
            series.ParentSeriesGroup.BubbleSizeRepresentation = BubbleSizeRepresentationType.Area;

            // Use literal values for bubble sizes
            series.DataPoints.DataSourceTypeForBubbleSizes = DataSourceType.DoubleLiterals;

            // Sample dataset: X values, Y values, and bubble sizes
            double[] xValues = new double[] { 1, 2, 3 };
            double[] yValues = new double[] { 4, 5, 6 };
            double[] bubbleSizes = new double[] { 10, 20, 30 };

            // Populate the series with data points
            for (int i = 0; i < xValues.Length; i++)
            {
                series.DataPoints.AddDataPointForBubbleSeries(xValues[i], yValues[i], bubbleSizes[i]);
            }

            // Save the presentation
            presentation.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}