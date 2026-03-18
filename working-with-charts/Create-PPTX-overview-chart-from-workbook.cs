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
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Workbook Data Overview");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20;

                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                int defaultWorksheetIndex = 0;
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                series1.Format.Fill.FillType = FillType.Solid;
                series1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Red;

                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

                series2.Format.Fill.FillType = FillType.Solid;
                series2.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Green;

                IDataLabel label = series2.DataPoints[0].Label;
                label.DataLabelFormat.ShowCategoryName = true;
                label = series2.DataPoints[1].Label;
                label.DataLabelFormat.ShowSeriesName = true;
                label = series2.DataPoints[2].Label;
                label.DataLabelFormat.ShowValue = true;
                label.DataLabelFormat.ShowSeriesName = true;
                label.DataLabelFormat.Separator = "/";

                pres.Save("WorkbookChart.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}