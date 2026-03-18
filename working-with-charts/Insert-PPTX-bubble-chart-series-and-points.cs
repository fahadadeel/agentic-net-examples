using System;
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
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a bubble chart
                IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 500, 400);

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                // Add categories (X axis labels)
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Add bubble data points: X, Y, Size
                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(0, 1, 1, 1.0), // X value
                    workbook.GetCell(0, 1, 2, 4.0), // Y value
                    workbook.GetCell(0, 1, 3, 30.0) // Bubble size
                );

                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(0, 2, 1, 2.0),
                    workbook.GetCell(0, 2, 2, 5.0),
                    workbook.GetCell(0, 2, 3, 40.0)
                );

                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(0, 3, 1, 3.0),
                    workbook.GetCell(0, 3, 2, 6.0),
                    workbook.GetCell(0, 3, 3, 50.0)
                );

                // Save the presentation
                pres.Save("BubbleChart.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}