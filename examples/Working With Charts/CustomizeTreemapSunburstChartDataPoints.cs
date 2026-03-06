using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var presentation = new Aspose.Slides.Presentation();
        var slide = presentation.Slides[0];

        // Treemap chart
        var treemapChart = slide.Shapes.AddChart(ChartType.Treemap, 50, 50, 500, 400);
        treemapChart.ChartData.Series.Clear();
        treemapChart.ChartData.Categories.Clear();

        int defaultWorksheetIndex = 0;
        var workbook = treemapChart.ChartData.ChartDataWorkbook;
        treemapChart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.Treemap);
        treemapChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
        treemapChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));

        var treemapSeries = treemapChart.ChartData.Series[0];
        var dp1 = treemapSeries.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
        var dp2 = treemapSeries.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 70));

        var level0 = dp1.DataPointLevels[0];
        level0.Label.DataLabelFormat.ShowValue = true;
        level0.Label.DataLabelFormat.ShowCategoryName = true;
        level0.Label.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
        level0.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

        // Sunburst chart
        var sunburstChart = slide.Shapes.AddChart(ChartType.Sunburst, 50, 500, 500, 400);
        sunburstChart.ChartData.Series.Clear();
        sunburstChart.ChartData.Categories.Clear();

        var workbook2 = sunburstChart.ChartData.ChartDataWorkbook;
        sunburstChart.ChartData.Series.Add(workbook2.GetCell(defaultWorksheetIndex, 0, 1, "Series S"), ChartType.Sunburst);
        sunburstChart.ChartData.Categories.Add(workbook2.GetCell(defaultWorksheetIndex, 1, 0, "Cat 1"));
        sunburstChart.ChartData.Categories.Add(workbook2.GetCell(defaultWorksheetIndex, 2, 0, "Cat 2"));

        var sunburstSeries = sunburstChart.ChartData.Series[0];
        var sdp1 = sunburstSeries.DataPoints.AddDataPointForSunburstSeries(workbook2.GetCell(defaultWorksheetIndex, 1, 1, 40));
        var sdp2 = sunburstSeries.DataPoints.AddDataPointForSunburstSeries(workbook2.GetCell(defaultWorksheetIndex, 2, 1, 60));

        var sLevel = sdp1.DataPointLevels[0];
        sLevel.Label.DataLabelFormat.ShowValue = true;
        sLevel.Label.DataLabelFormat.ShowSeriesName = true;
        sLevel.Label.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
        sLevel.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

        presentation.Save("CustomizedTreemapSunburst.pptx", SaveFormat.Pptx);
    }
}