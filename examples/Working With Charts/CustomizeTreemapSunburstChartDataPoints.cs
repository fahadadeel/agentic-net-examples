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
        Presentation presentation = new Presentation();

        // Add a Treemap chart
        IChart treemapChart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 50, 50, 500, 400);
        treemapChart.ChartData.Series.Clear();
        treemapChart.ChartData.Categories.Clear();

        int defaultWorksheetIndex = 0;
        IChartDataWorkbook workbook = treemapChart.ChartData.ChartDataWorkbook;

        // Add a series for the Treemap
        IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.Treemap);

        // Add categories (required for Treemap)
        treemapChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
        treemapChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));

        // Add first data point with size value
        IChartDataCell sizeCell1 = workbook.GetCell(defaultWorksheetIndex, 1, 1, 30);
        IChartDataPoint treemapDataPoint1 = treemapSeries.DataPoints.AddDataPointForTreemapSeries(sizeCell1);
        IChartDataPointLevel treemapLevel1 = treemapDataPoint1.DataPointLevels[0];
        treemapLevel1.Label.DataLabelFormat.ShowValue = true;
        treemapLevel1.Label.DataLabelFormat.ShowCategoryName = true;

        // Add second data point with size value
        IChartDataCell sizeCell2 = workbook.GetCell(defaultWorksheetIndex, 2, 1, 70);
        IChartDataPoint treemapDataPoint2 = treemapSeries.DataPoints.AddDataPointForTreemapSeries(sizeCell2);
        IChartDataPointLevel treemapLevel2 = treemapDataPoint2.DataPointLevels[0];
        treemapLevel2.Label.DataLabelFormat.ShowValue = true;
        treemapLevel2.Label.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
        treemapLevel2.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

        // Add a Sunburst chart
        IChart sunburstChart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50, 460, 500, 400);
        sunburstChart.ChartData.Series.Clear();
        sunburstChart.ChartData.Categories.Clear();

        // Add a series for the Sunburst
        IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Sunburst Series"), ChartType.Sunburst);

        // Add categories (required for Sunburst)
        sunburstChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Level 1"));
        sunburstChart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Level 2"));

        // Add first data point with size value
        IChartDataCell sizeCellS1 = workbook.GetCell(defaultWorksheetIndex, 1, 1, 40);
        IChartDataPoint sunburstDataPoint1 = sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sizeCellS1);
        IChartDataPointLevel sunburstLevel1 = sunburstDataPoint1.DataPointLevels[0];
        sunburstLevel1.Label.DataLabelFormat.ShowValue = true;
        sunburstLevel1.Label.DataLabelFormat.ShowCategoryName = false;

        // Add second data point with size value
        IChartDataCell sizeCellS2 = workbook.GetCell(defaultWorksheetIndex, 2, 1, 60);
        IChartDataPoint sunburstDataPoint2 = sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sizeCellS2);
        IChartDataPointLevel sunburstLevel2 = sunburstDataPoint2.DataPointLevels[0];
        sunburstLevel2.Label.DataLabelFormat.ShowValue = true;
        sunburstLevel2.Label.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
        sunburstLevel2.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        presentation.Save("CustomizeDataPoints_out.pptx", SaveFormat.Pptx);
    }
}