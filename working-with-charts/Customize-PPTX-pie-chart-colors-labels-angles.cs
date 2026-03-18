using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace PieChartCustomization
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

                    // Add a pie chart to the slide
                    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

                    // Get the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    int defaultWorksheetIndex = 0;

                    // Clear default generated series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add a new series
                    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.Pie);

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

                    // Add data points for the pie series
                    IChartDataPoint pointA = series.DataPoints.AddDataPointForPieSeries(40);
                    IChartDataPoint pointB = series.DataPoints.AddDataPointForPieSeries(30);
                    IChartDataPoint pointC = series.DataPoints.AddDataPointForPieSeries(30);

                    // Customize slice colors
                    pointA.Format.Fill.FillType = FillType.Solid;
                    pointA.Format.Fill.SolidFillColor.Color = Color.Red;

                    pointB.Format.Fill.FillType = FillType.Solid;
                    pointB.Format.Fill.SolidFillColor.Color = Color.Green;

                    pointC.Format.Fill.FillType = FillType.Solid;
                    pointC.Format.Fill.SolidFillColor.Color = Color.Blue;

                    // Explode the first slice
                    pointA.Explosion = 20;

                    // Set data label options for the series
                    series.Labels.DefaultDataLabelFormat.ShowValue = true;
                    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
                    series.Labels.DefaultDataLabelFormat.ShowPercentage = true;
                    series.Labels.DefaultDataLabelFormat.Separator = " - ";

                    // Set the first slice angle (rotate the pie)
                    series.ParentSeriesGroup.FirstSliceAngle = 45;

                    // Enable varied colors for each data point (if needed)
                    series.ParentSeriesGroup.IsColorVaried = true;

                    // Save the presentation
                    presentation.Save("CustomizedPieChart.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}