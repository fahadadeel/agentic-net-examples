using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace PieChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a pie chart
                    Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

                    // Set chart title
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
                    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                    chart.ChartTitle.Height = 20;

                    // Get the chart data workbook
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add a new series
                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                        workbook.GetCell(0, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.Pie);

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Product A"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Product B"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Product C"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Product D"));

                    // Populate series with data points
                    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
                    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 20));
                    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 25));
                    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 4, 1, 25));

                    // Enable varied colors for each slice
                    series.ParentSeriesGroup.IsColorVaried = true;

                    // Show values on data labels
                    series.Labels.DefaultDataLabelFormat.ShowValue = true;

                    // Save the presentation
                    presentation.Save("PieChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}