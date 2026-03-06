using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        var presentation = new Aspose.Slides.Presentation();
        var slide = presentation.Slides[0];
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.BoxAndWhisker, 0, 0, 500, 400);
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Box and Whisker Chart");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
        chart.ChartTitle.Height = 20;

        int defaultWorksheetIndex = 0;
        var fact = chart.ChartData.ChartDataWorkbook;

        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        var series = chart.ChartData.Series[0];
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 5));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 8));
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 3));

        presentation.Save("BoxWhiskerChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}