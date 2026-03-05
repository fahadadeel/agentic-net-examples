using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Access the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add first series and populate data points
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 10));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

            // Add a linear trendline to the first series
            Aspose.Slides.Charts.ITrendline trendline = series1.TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
            trendline.DisplayEquation = true;
            trendline.DisplayRSquaredValue = true;

            // Save the presentation to a file
            pres.Save("ChartWithTrendline.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}