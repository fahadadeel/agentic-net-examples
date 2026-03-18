using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartActualValuesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                    // Get the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add two series
                    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

                    // Add three categories
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                    // Populate data for Series 1
                    IChartSeries series1 = chart.ChartData.Series[0];
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                    // Populate data for Series 2
                    IChartSeries series2 = chart.ChartData.Series[1];
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

                    // Validate chart layout to calculate actual values
                    chart.ValidateChartLayout();

                    // Output actual axis values
                    IAxis verticalAxis = chart.Axes.VerticalAxis;
                    IAxis horizontalAxis = chart.Axes.HorizontalAxis;

                    Console.WriteLine("Vertical Axis Actual Min Value: " + verticalAxis.ActualMinValue);
                    Console.WriteLine("Vertical Axis Actual Max Value: " + verticalAxis.ActualMaxValue);
                    Console.WriteLine("Horizontal Axis Actual Min Value: " + horizontalAxis.ActualMinValue);
                    Console.WriteLine("Horizontal Axis Actual Max Value: " + horizontalAxis.ActualMaxValue);

                    // Iterate through series and data points to display actual layout values
                    for (int i = 0; i < chart.ChartData.Series.Count; i++)
                    {
                        IChartSeries series = chart.ChartData.Series[i];
                        Console.WriteLine($"Series {i + 1} Name: {series.Name.AsLiteralString}");

                        for (int j = 0; j < series.DataPoints.Count; j++)
                        {
                            IChartDataPoint point = series.DataPoints[j];
                            Console.WriteLine($"  Data Point {j + 1}:");
                            Console.WriteLine($"    Value: {point.Value.AsLiteralDouble}");
                            Console.WriteLine($"    Actual X: {point.ActualX}");
                            Console.WriteLine($"    Actual Y: {point.ActualY}");
                            Console.WriteLine($"    Actual Width: {point.ActualWidth}");
                            Console.WriteLine($"    Actual Height: {point.ActualHeight}");
                        }
                    }

                    // Save the presentation
                    presentation.Save("ChartActualValues.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}