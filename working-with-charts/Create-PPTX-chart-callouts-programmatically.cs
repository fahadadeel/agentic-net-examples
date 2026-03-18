using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

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
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                // Add data points
                IChartDataPoint point1 = series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                IChartDataPoint point2 = series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 40));
                IChartDataPoint point3 = series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                // Enable callouts for all data labels in the series
                series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Format callout for the first data point
                point1.Format.Fill.SolidFillColor.Color = Color.Blue;
                point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;

                // Disable callout for the second data point
                series.DataPoints[1].Label.DataLabelFormat.ShowLabelAsDataCallout = false;

                // Remove the third data point entirely
                series.DataPoints[2].Remove();

                // Save the presentation
                presentation.Save("ChartCalloutExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}