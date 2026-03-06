using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace TreeMapChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a TreeMap chart
            IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 50f, 50f, 500f, 400f);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sample TreeMap Chart");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
            chart.ChartTitle.Height = 20f;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add a series
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

            // Add categories (hierarchical levels)
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

            // Populate data points for the series
            IChartSeries series = chart.ChartData.Series[0];
            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 20));

            // Set fill colors for the series
            series.Format.Fill.FillType = FillType.Solid;
            series.Format.Fill.SolidFillColor.Color = Color.Orange;

            // Save the presentation
            presentation.Save("TreeMapChart_out.pptx", SaveFormat.Pptx);
        }
    }
}