using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

                    // Get the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add a new series
                    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                    // Add data points to the series
                    IChartDataPoint point1 = series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                    IChartDataPoint point2 = series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                    IChartDataPoint point3 = series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                    // Set custom fill color for the first data point
                    point1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                    point1.Format.Fill.SolidFillColor.Color = Color.Blue;

                    // Assign a custom label to the first data point
                    point1.Label.AddTextFrameForOverriding("Custom Label");
                    // Optionally show the label as a callout
                    point1.Label.DataLabelFormat.ShowLabelAsDataCallout = true;

                    // Save the presentation
                    pres.Save("CustomLabelAndFill.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}