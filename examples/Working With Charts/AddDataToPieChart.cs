using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddDataToPieChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 400f, 400f);

            // Remove the default sample series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook (factory for cells)
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories (labels for the pie slices)
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Apples"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Bananas"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Cherries"));

            // Add a series and give it a name
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Fruits"), chart.Type);

            // Populate the series with data points for the pie chart
            series.DataPoints.AddDataPointForPieSeries(30.0); // Apples
            series.DataPoints.AddDataPointForPieSeries(45.0); // Bananas
            series.DataPoints.AddDataPointForPieSeries(25.0); // Cherries

            // Optionally explode the second slice (Bananas) for visual emphasis
            series.DataPoints[1].Explosion = 20; // 20% explosion

            // Save the presentation to disk
            pres.Save("AddDataToPieChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}