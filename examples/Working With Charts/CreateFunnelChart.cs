using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace FunnelChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a funnel chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Funnel, 0f, 0f, 500f, 400f);

            // Clear any default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the workbook to create cells
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            workbook.Clear(0); // Clear the first worksheet

            // Add categories (stages of the funnel)
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Stage 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Stage 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Stage 3"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Stage 4"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Stage 5"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Stage 6"));

            // Add a series for the funnel chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Funnel);

            // Add data points (values for each stage)
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 120));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 80));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 60));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 40));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 20));

            // Save the presentation
            presentation.Save("FunnelChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}