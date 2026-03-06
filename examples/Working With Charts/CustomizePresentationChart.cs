using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using System.Drawing;

namespace CustomizeChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    0f, 0f, 500f, 500f);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Comparison");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20f;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get reference to the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));

                // Add series
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Product A"), chart.Type);
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Product B"), chart.Type);

                // Populate data for first series
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 120));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 150));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 170));

                // Set fill color for first series
                series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series1.Format.Fill.SolidFillColor.Color = Color.Red;

                // Populate data for second series
                Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 80));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 130));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 190));

                // Set fill color for second series
                series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series2.Format.Fill.SolidFillColor.Color = Color.Green;

                // Customize data labels
                IDataLabel label = series1.DataPoints[0].Label;
                label.DataLabelFormat.ShowCategoryName = true;

                label = series1.DataPoints[1].Label;
                label.DataLabelFormat.ShowSeriesName = true;

                label = series1.DataPoints[2].Label;
                label.DataLabelFormat.ShowValue = true;
                label.DataLabelFormat.ShowSeriesName = true;
                label.DataLabelFormat.Separator = "/";

                // Save the presentation
                presentation.Save("CustomizedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}