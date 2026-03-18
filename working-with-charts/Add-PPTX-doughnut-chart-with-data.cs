using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a doughnut chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Doughnut, // Chart type
                    50,   // X position (points)
                    50,   // Y position (points)
                    500,  // Width (points)
                    400   // Height (points)
                );

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Doughnut Chart");

                // Remove default sample data
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Index of the default worksheet
                int defaultWorksheetIndex = 0;

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add a series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                    chart.Type
                );

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

                // Populate series with data points
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 20));

                // Enable automatic varied colors for each slice
                series.ParentSeriesGroup.IsColorVaried = true;

                // Save the presentation
                pres.Save("DoughnutChart_out.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}