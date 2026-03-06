using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        Presentation presentation = new Presentation();
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        int defaultWorksheetIndex = 0;
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add a series
        IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.Funnel);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add data points for the funnel series
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 20));

        // Set fill color for the series
        series.Format.Fill.FillType = FillType.Solid;
        series.Format.Fill.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        presentation.Save("FunnelChart_out.pptx", SaveFormat.Pptx);
    }
}