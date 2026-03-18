using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace MaintainNumericConstants
{
    class Program
    {
        // Define numeric constants to be used across slides
        private const double SalesTarget = 150000.0;
        private const double ProfitMargin = 0.25;

        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a clustered column chart (float parameters required)
                    IChart chart = slide.Shapes.AddChart(
                        ChartType.ClusteredColumn,
                        0f, 0f, 500f, 400f);

                    // Set chart title
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding("Quarterly Performance");
                    chart.ChartTitle.TextFrameForOverriding.Text = "Quarterly Performance";

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Get the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Add categories (e.g., Q1, Q2, Q3, Q4)
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Q3"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Q4"));

                    // Add two series: Sales and Profit
                    IChartSeries salesSeries = chart.ChartData.Series.Add(
                        workbook.GetCell(0, 0, 1, "Sales"), chart.Type);
                    IChartSeries profitSeries = chart.ChartData.Series.Add(
                        workbook.GetCell(0, 0, 2, "Profit"), chart.Type);

                    // Populate series data using the defined constants
                    // Sales data (using SalesTarget constant)
                    salesSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, SalesTarget));
                    salesSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, SalesTarget * 0.9));
                    salesSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, SalesTarget * 1.1));
                    salesSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 4, 1, SalesTarget * 1.05));

                    // Profit data (using ProfitMargin constant)
                    profitSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, SalesTarget * ProfitMargin));
                    profitSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, SalesTarget * 0.9 * ProfitMargin));
                    profitSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, SalesTarget * 1.1 * ProfitMargin));
                    profitSeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 4, 2, SalesTarget * 1.05 * ProfitMargin));

                    // Save the presentation
                    pres.Save("MaintainNumericConstants_out.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}