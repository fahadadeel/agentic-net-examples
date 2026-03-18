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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50, 50, 500, 400);

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                wb.GetCell(0, 0, 1, "Series 1"),
                chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "Category 3"));

            // Populate series with data points
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, 1, 1, 20));
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, 2, 1, 50));
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, 3, 1, 30));

            // Assign a specific color to the second data point (index 1)
            Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[1];
            point.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            point.Format.Fill.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            pres.Save("AssignBranchColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}