using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20f;

                // Show values for the first series
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Get the default worksheet index and workbook
                int defaultWorksheetIndex = 0;
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add series
                chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "2019"),
                    chart.Type);
                chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 2, "2020"),
                    chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(
                    workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
                chart.ChartData.Categories.Add(
                    workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
                chart.ChartData.Categories.Add(
                    workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));

                // Populate first series data
                Aspose.Slides.Charts.IChartSeries series0 = chart.ChartData.Series[0];
                series0.DataPoints.AddDataPointForBarSeries(
                    workbook.GetCell(defaultWorksheetIndex, 1, 1, 150));
                series0.DataPoints.AddDataPointForBarSeries(
                    workbook.GetCell(defaultWorksheetIndex, 2, 1, 200));
                series0.DataPoints.AddDataPointForBarSeries(
                    workbook.GetCell(defaultWorksheetIndex, 3, 1, 250));

                // Populate second series data
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[1];
                series1.DataPoints.AddDataPointForBarSeries(
                    workbook.GetCell(defaultWorksheetIndex, 1, 2, 180));
                series1.DataPoints.AddDataPointForBarSeries(
                    workbook.GetCell(defaultWorksheetIndex, 2, 2, 230));
                series1.DataPoints.AddDataPointForBarSeries(
                    workbook.GetCell(defaultWorksheetIndex, 3, 2, 300));

                // Save the presentation
                pres.Save("ChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}