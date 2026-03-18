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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart without sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400, false);

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.ClusteredColumn);
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), Aspose.Slides.Charts.ChartType.ClusteredColumn);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Populate data points for series1
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

            // Populate data points for series2
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

            // Set fill colors for the series
            series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series1.Format.Fill.SolidFillColor.Color = Color.Red;
            series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series2.Format.Fill.SolidFillColor.Color = Color.Green;

            // Validate layout to compute actual values
            chart.ValidateChartLayout();

            // Output actual values for each data point
            foreach (Aspose.Slides.Charts.IChartSeries series in chart.ChartData.Series)
            {
                foreach (Aspose.Slides.Charts.IChartDataPoint point in series.DataPoints)
                {
                    Console.WriteLine("Series: {0}, Category Index: {1}, ActualX: {2}, ActualY: {3}, ActualWidth: {4}, ActualHeight: {5}",
                        series.Name.AsLiteralString,
                        point.Index,
                        point.ActualX,
                        point.ActualY,
                        point.ActualWidth,
                        point.ActualHeight);
                }
            }

            // Save the presentation
            presentation.Save("ChartActualValues.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}