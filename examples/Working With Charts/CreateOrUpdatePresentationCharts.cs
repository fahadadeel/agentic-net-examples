using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a chart without sample data for custom configuration
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0f, 0f, 500f, 500f, false);

        // Set chart title
        chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
        chart.ChartTitle.Height = 20f;
        chart.HasTitle = true;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get workbook and default worksheet index
        int defaultWorksheetIndex = 0;
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add series
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Populate first series data
        IChartSeries series0 = chart.ChartData.Series[0];
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
        series0.Format.Fill.FillType = FillType.Solid;
        series0.Format.Fill.SolidFillColor.Color = Color.Red;

        // Populate second series data
        IChartSeries series1 = chart.ChartData.Series[1];
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));
        series1.Format.Fill.FillType = FillType.Solid;
        series1.Format.Fill.SolidFillColor.Color = Color.Green;

        // Configure data labels for the first series
        IDataLabel label0 = series0.DataPoints[0].Label;
        label0.DataLabelFormat.ShowCategoryName = true;

        IDataLabel label1 = series0.DataPoints[1].Label;
        label1.DataLabelFormat.ShowSeriesName = true;

        IDataLabel label2 = series0.DataPoints[2].Label;
        label2.DataLabelFormat.ShowValue = true;
        label2.DataLabelFormat.ShowSeriesName = true;
        label2.DataLabelFormat.Separator = "/";

        // Save the presentation
        pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
    }
}