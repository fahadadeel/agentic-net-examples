using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 400);

            // Access the chart's data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a new series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add categories (pie slices)
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

            // Add data points for each slice
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 50));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 20));

            // Explode the pie slices by setting the Explosion property (percentage of the pie diameter)
            series.Explosion = 20; // 20% offset for all slices

            // Save the presentation
            presentation.Save("ExplodedPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}