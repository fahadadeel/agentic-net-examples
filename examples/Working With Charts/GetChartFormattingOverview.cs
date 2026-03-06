using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a chart without sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0, 0, 500, 400, false);

        // Set chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Chart Formatting Overview");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
        chart.ChartTitle.Height = 20;

        // Get chart data workbook
        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Populate series1 data points
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

        // Set fill color for series1
        series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Red;

        // Populate series2 data points
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

        // Set fill color for series2
        series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series2.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Green;

        // Show values for series1
        series1.Labels.DefaultDataLabelFormat.ShowValue = true;

        // Customize data labels for series2
        Aspose.Slides.Charts.IDataLabel lbl0 = series2.DataPoints[0].Label;
        lbl0.DataLabelFormat.ShowCategoryName = true;

        Aspose.Slides.Charts.IDataLabel lbl1 = series2.DataPoints[1].Label;
        lbl1.DataLabelFormat.ShowSeriesName = true;

        Aspose.Slides.Charts.IDataLabel lbl2 = series2.DataPoints[2].Label;
        lbl2.DataLabelFormat.ShowValue = true;
        lbl2.DataLabelFormat.ShowSeriesName = true;
        lbl2.DataLabelFormat.Separator = "/";

        // Save the presentation
        pres.Save("ChartFormattingOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}